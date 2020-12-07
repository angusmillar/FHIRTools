using System;
using System.Collections.Generic;
using System.Text;
using Hl7.FhirPath.Expressions;

namespace FHIRTools.R4.Common.FhirPathTools
{
  public class ParseExpressionOutCome
  {
    public string  ErrorMessage { get; set; }
    public bool PasreOk { get; set; }
    public Expression Expression { get; set; }
    public string ExpressionString { get; set; }
  }
}
