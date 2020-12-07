using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;

namespace FHIRTools.Stu3.ResourceLoader
{
  class Program
  {
    static void Main(string[] args)
    {
      //string FhirServerEndpoint = "http://localhost:8888/Fhir";
      string FhirServerEndpoint = "https://stu3.test.pyrohealth.net/fhir";

      AuDefinitionsDownLoader AuDefinitionsDownLoader = new AuDefinitionsDownLoader();
      List<AuDefinition> AuDefList = AuDefinitionsDownLoader.GetResourceList();

      var TranBundle = new Bundle();
      TranBundle.Type = Bundle.BundleType.Transaction;
      TranBundle.Entry = new List<Bundle.EntryComponent>();
      foreach (AuDefinition Def in AuDefList)
      {
        var Entry = new Bundle.EntryComponent();
        Entry.FullUrl = $"urn:uuid:{Guid.NewGuid()}";
        Entry.Resource = Def.Resource;
        Entry.Request = new Bundle.RequestComponent();
        Entry.Request.Method = Bundle.HTTPVerb.PUT;
        Entry.Request.Url = $"{Def.ResourceType.GetLiteral()}/{Def.FhirId}";
        TranBundle.Entry.Add(Entry);
      }


      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(FhirServerEndpoint, false);
      clientFhir.Timeout = 1000 * 1000;

      Bundle TransactionResult = null;
      try
      {
        Console.WriteLine($"Uploading Transaction bundle to {FhirServerEndpoint}");
        TransactionResult = clientFhir.Transaction(TranBundle);
        Console.WriteLine("Transaction bundle commit successful");
        
      }
      catch (Exception Exec)
      {
        Console.WriteLine("Error is POST of Transaction Bundle, see error below.");
        Console.Write(Exec.Message);
      }

      Console.WriteLine("Hit Any key to end.");
      Console.ReadKey();


    }
  }
}
