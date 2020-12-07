using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FHIRTools.Stu3.SearchParametersInspector
{
  public class SearchParametersToFile
  {
    public void Process()
    {
      string ResourceRequired = ResourceType.AuditEvent.GetLiteral();
      string FilePath = @"C:\temp\FhirSearchParameters.txt";
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"{"Resource".PadRight(27, ' ')}, {"Name".PadRight(20, ' ')}, {"Expression".PadRight(40, ' ')}, {"Target".PadRight(20, ' ')}");
      sb.AppendLine($"-".PadRight(100, '-'));
      foreach (var Param in ModelInfo.SearchParameters)
      {
        if (true)
        //if (Param.Resource == ResourceRequired || ResourceRequired == ResourceType.Resource.GetLiteral())
        {

          if (Param.Type == SearchParamType.Reference)
          {
            if (Param.Target == null)
            {
              Console.WriteLine($"Resource: {Param.Resource}, Name: {Param.Name}, Path: {Param.Expression}");
              //sb.AppendLine($"{Param.Resource.PadRight(27, ' ')}, {Param.Name.PadRight(30, ' ')}, {Param.Type.GetLiteral().PadRight(10, ' ')} {Param.Expression.PadRight(20, ' ')}");
              sb.AppendLine($"{Param.Resource.PadRight(27, ' ')}, {Param.Name.PadRight(20, ' ')}, {Param.Expression.PadRight(40, ' ')}, {"None".PadRight(20, ' ')}");

            }
            else
            {
              foreach (var Target in Param.Target)
              {
                Console.WriteLine($"Resource: {Param.Resource}, Name: {Param.Name}, Path: {Param.Expression}");
                //sb.AppendLine($"{Param.Resource.PadRight(27, ' ')}, {Param.Name.PadRight(30, ' ')}, {Param.Type.GetLiteral().PadRight(10, ' ')} {Param.Expression.PadRight(20, ' ')}");
                sb.AppendLine($"{Param.Resource.PadRight(27, ' ')}, {Param.Name.PadRight(20, ' ')}, {Param.Expression.PadRight(40, ' ')}, {Target.GetLiteral().PadRight(20, ' ')}");
              }
            }
          }
        }
      }
      File.WriteAllText(FilePath, sb.ToString());
      Console.WriteLine($"File Writen to: {FilePath}");
      Console.ReadKey();


    }
  }
}
