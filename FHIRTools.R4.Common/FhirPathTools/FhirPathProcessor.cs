using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;
using Hl7.FhirPath;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir.ElementModel;

namespace FHIRTools.R4.Common.FhirPathTools
{
  public class FhirPathProcessor
  {

    public CompiledExpressionOutCome GetCompiledExpression(Resource Resource, ParseExpressionOutCome ParseExpressionOutCome)
    {
      CompiledExpressionOutCome CompiledExpressionOutCome = new CompiledExpressionOutCome();
      CompiledExpressionOutCome.ParseExpressionOutCome = ParseExpressionOutCome;      
      Hl7.FhirPath.FhirPathCompiler.DefaultSymbolTable.AddFhirExtensions();
      FhirPathCompiler Compiler = new FhirPathCompiler();

      var PocoNavigator = Resource.ToTypedElement();

      //var PocoNavigator = new Hl7.Fhir.ElementModel.PocoNavigator(Resource);      
      try
      {
        CompiledExpressionOutCome.CompiledExpression = Compiler.Compile(ParseExpressionOutCome.ExpressionString);
      }
      catch (Exception ex)
      {
        CompiledExpressionOutCome.Ok = false;
        CompiledExpressionOutCome.ErrorMessage = ex.Message;        
        return CompiledExpressionOutCome;
      }
      if (CompiledExpressionOutCome.CompiledExpression != null)
      {
        try
        {
          var oFhirEvaluationContext = new Hl7.Fhir.FhirPath.FhirEvaluationContext(PocoNavigator);
          oFhirEvaluationContext.ElementResolver = CustomFhirPathResolver.Resolver;
          CompiledExpressionOutCome.Ok = CompiledExpressionOutCome.CompiledExpression.Predicate(PocoNavigator, oFhirEvaluationContext);
        }
        catch(System.Exception Exec)
        {
          CompiledExpressionOutCome.Ok = false;
          CompiledExpressionOutCome.ErrorMessage = Exec.Message;
          return CompiledExpressionOutCome;
        }
      }
      return CompiledExpressionOutCome;
    }


    
    public ParseExpressionOutCome ParseExpression(string Expression)
    {
      var OutCome = new ParseExpressionOutCome();
      OutCome.ExpressionString = Expression;
      Hl7.FhirPath.FhirPathCompiler.DefaultSymbolTable.AddFhirExtensions();
      FhirPathCompiler Compiler = new FhirPathCompiler();      
      try
      {
        OutCome.Expression = Compiler.Parse(Expression);
        OutCome.PasreOk = true;
        return OutCome;
      }
      catch(Exception Exec)
      {
        OutCome.PasreOk = false;
        OutCome.ErrorMessage = Exec.Message;
        return OutCome;
      }
    }
  }
}
