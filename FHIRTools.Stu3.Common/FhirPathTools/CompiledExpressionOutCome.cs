using System;
using System.Collections.Generic;
using System.Text;
using Hl7.FhirPath;

namespace FHIRTools.Stu3.Common.FhirPathTools
{
  public class CompiledExpressionOutCome
  {
    public ParseExpressionOutCome ParseExpressionOutCome { get; set; }
    public CompiledExpression CompiledExpression { get; set; }
    public bool Ok { get; set; }
    public string ErrorMessage { get; set; }
  }
}
