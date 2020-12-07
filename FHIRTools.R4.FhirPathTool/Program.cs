using System;
using System.Collections.Generic;

namespace FHIRTools.R4.FhirPathTool
{
  class Program
  {
    static void Main(string[] args)
    {
      FhirPathProcessor FhirPathProcessor = new FhirPathProcessor();
      FhirPathProcessor.ProcessExpression();
      Console.WriteLine("");
      Console.WriteLine("Finished");
      Console.ReadKey();
    }
  }
}
