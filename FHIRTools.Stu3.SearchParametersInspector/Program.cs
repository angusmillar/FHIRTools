using System;

namespace FHIRTools.Stu3.SearchParametersInspector
{
  class Program
  {
    static void Main(string[] args)
    {
      //SearchParametersToFile SearchParametersToFile = new SearchParametersToFile();
      //SearchParametersToFile.Process();
      //Console.WriteLine("Done");
      //Console.ReadKey();

      SearchParameterFhirPathExpression SearchParameterFhirPathExpression = new SearchParameterFhirPathExpression();
      SearchParameterFhirPathExpression.Process();
      Console.WriteLine("Done");
      Console.ReadKey();
    }
  }
}
