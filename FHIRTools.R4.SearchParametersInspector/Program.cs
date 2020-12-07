using System;

namespace FHIRTools.R4.SearchParametersInspector
{
  class Program
  {
    static void Main(string[] args)
    {
      //SearchParametersToFile SearchParametersToFile = new SearchParametersToFile();
      //SearchParametersToFile.Process();
      //Console.WriteLine("Done");
      //Console.ReadKey();

      //Hl7.Fhir.Model.FhirDateTime testDate = new Hl7.Fhir.Model.FhirDateTime("2015-01-02");
      //DateTimeOffset? undeclared = testDate.ToDateTimeOffset(new TimeSpan(0, 0, 0));
      //DateTimeOffset? inMelb = testDate.ToNewDateTimeOffset(new TimeSpan(11, 0, 0));
      //DateTimeOffset? inBoston = testDate.ToNewDateTimeOffset(new TimeSpan(-5, 0, 0));

      //Console.WriteLine($"Undeclared Timezone: {undeclared.ToString()}");
      //Console.WriteLine($"Melbourne: {inMelb.ToString()}");
      //Console.WriteLine($"Boston: {inBoston.ToString()}");

      //Hl7.Fhir.Model.FhirDateTime FhirDate = new Hl7.Fhir.Model.FhirDateTime("2015-01-02T10:30:20");

      //DateTime a = new DateTime(2015, 01, 02);
      //DateTime b = DateTime.SpecifyKind(FhirDate.ToDateTimeOffset(DateTimeOffset.Now.Offset).UtcDateTime, DateTimeKind.Unspecified);

      //var NewB = FhirDate.ToNewDateTimeOffset(new TimeSpan(-5, 0, 0));

      //if (a == b)
      //{
      //  Console.WriteLine($"A and B are equal.");
      //}

      //DateTimeOffset DTO_A = new DateTimeOffset(a, new TimeSpan(-5, 0, 0));
      //DateTimeOffset DTO_B = new DateTimeOffset(b, new TimeSpan(-5, 0, 0));
      //if (DTO_A == NewB)
      //{
      //  Console.WriteLine($"DateTimeOffset_A and DateTimeOffset_B are equal.");
      //}




      SearchParameterFhirPathExpression SearchParameterFhirPathExpression = new SearchParameterFhirPathExpression();
      SearchParameterFhirPathExpression.Process();
      Console.WriteLine("Done");
      Console.ReadKey();
    }

  }


  public static class MyExtensions
  {
    public static DateTimeOffset? ToNewDateTimeOffset(this Hl7.Fhir.Model.FhirDateTime FhirDate, TimeSpan TimeSpan)
    {
        return FhirDate.ToDateTimeOffset(TimeSpan);           
    }
  }


}
