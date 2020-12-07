using System;

namespace FHIRTools.Stu3.FhirPathTool
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
