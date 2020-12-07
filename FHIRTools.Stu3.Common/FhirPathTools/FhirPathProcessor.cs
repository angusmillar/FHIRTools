using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;
using Hl7.FhirPath;

namespace FHIRTools.Stu3.Common.FhirPathTools
{
  public class FhirPathProcessor
  {

    public CompiledExpressionOutCome GetCompiledExpression(Resource Resource, ParseExpressionOutCome ParseExpressionOutCome)
    {
      CompiledExpressionOutCome CompiledExpressionOutCome = new CompiledExpressionOutCome();
      CompiledExpressionOutCome.ParseExpressionOutCome = ParseExpressionOutCome;

      FhirPathCompiler Compiler = new FhirPathCompiler();
      var PocoNavigator = new Hl7.Fhir.ElementModel.PocoNavigator(Resource);      
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
        CompiledExpressionOutCome.Ok = CompiledExpressionOutCome.CompiledExpression.Predicate(PocoNavigator, new Hl7.Fhir.FhirPath.FhirEvaluationContext(PocoNavigator));
      }
      return CompiledExpressionOutCome;
    }

    public ParseExpressionOutCome ParseExpression(string Expression)
    {
      var OutCome = new ParseExpressionOutCome();
      OutCome.ExpressionString = Expression;
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
