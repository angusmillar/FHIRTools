using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FHIRTools.R4.Common;
using Hl7.Fhir.Utility;

namespace FHIRTools.R4.SearchParametersInspector
{
  public class SearchParameterFhirPathExpression
  {
    private FhirSpecExamplesTool FhirSpecExamplesTool;
    private string FilePath = @"C:\temp\R4FhirSpecExampleSearchParametersExpCheck.txt";

    public void Process()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"{"Resource".PadRight(27, ' ')}, {"Name".PadRight(20, ' ')}, {"Expression".PadRight(30, ' ')}, {"Error".PadRight(40, ' ')}");
      sb.AppendLine($"-".PadRight(100, '-'));

      FhirSpecExamplesTool = new FhirSpecExamplesTool();
      FHIRTools.R4.Common.SearchParameterTools SearchParameterTools = new Common.SearchParameterTools();
      var SearchParamneterDefList = SearchParameterTools.GetSearchParameterDefinitionList();

      FHIRTools.R4.Common.FhirPathTools.FhirPathProcessor FhirPathProcessor = new Common.FhirPathTools.FhirPathProcessor();
      
      foreach (var SearchParam in SearchParamneterDefList)
      {
        if (!string.IsNullOrWhiteSpace(SearchParam.Expression))
        {
          var ParseExpressionOutCome = FhirPathProcessor.ParseExpression(SearchParam.Expression);
          if (!ParseExpressionOutCome.PasreOk)
          {
            Console.WriteLine($"SearchParam for Resource {SearchParam.Base.ToString()} with Name {SearchParam.Name} has error. ");
            Console.WriteLine($"Expression was: {SearchParam.Expression}");
            Console.WriteLine($"Error was: {ParseExpressionOutCome.ErrorMessage}");
          }
          else
          {
            foreach(var BaseResourceType in SearchParam.Base)
            {              
              var ExampleList = FhirSpecExamplesTool.GetResourceByResourceType(BaseResourceType.Value);
              foreach(var Res in ExampleList)
              {
                var CompiledExpressionOutrCome = FhirPathProcessor.GetCompiledExpression(Res, ParseExpressionOutCome);
                if (!CompiledExpressionOutrCome.Ok)
                {
                  if (string.IsNullOrWhiteSpace(CompiledExpressionOutrCome.ErrorMessage))
                  {
                    sb.AppendLine($"{Res.ResourceType.GetLiteral().PadRight(27, ' ')}, {SearchParam.Name.PadRight(20, ' ')}, {CompiledExpressionOutrCome.ParseExpressionOutCome.ExpressionString.PadRight(30, ' ')}");
                  }
                  else
                  {
                    sb.AppendLine($"{Res.ResourceType.GetLiteral().PadRight(27, ' ')}, {SearchParam.Name.PadRight(20, ' ')}, {CompiledExpressionOutrCome.ParseExpressionOutCome.ExpressionString.PadRight(30, ' ')}, {CompiledExpressionOutrCome.ErrorMessage.PadRight(40, ' ')}");
                  }                  
                  Console.WriteLine($"Resource {Res.ResourceType.GetLiteral()} with Search Name {SearchParam.Name} has error. ");
                  Console.WriteLine($"Expression was: {CompiledExpressionOutrCome.ParseExpressionOutCome.ExpressionString}");
                  Console.WriteLine($"Error was: {CompiledExpressionOutrCome.ErrorMessage}");
                }
              }             
            }
          }
        }
      }

      File.WriteAllText(FilePath, sb.ToString());
    }
  }
}
