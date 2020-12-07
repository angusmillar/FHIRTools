using System;
using System.Security.Cryptography.X509Certificates;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace FHIRTools.Stu3.AdhaProviderDirectory
{
  class Program
  {
    static void Main(string[] args)
    {
      //One of the test endpoints 
      string adhaPDEndpoint = "https://sandbox.digitalhealth.gov.au/FhirServerSTU3-PDA/fhir";

      //New up a FHIR client to make the request
      FhirClient client = new FhirClient(adhaPDEndpoint);

      // Load certificate used to sign the client request
      X509Certificate2 signingCert = GetCertificate(
          "06fba6",
          X509FindType.FindBySerialNumber,
          StoreName.My,
          StoreLocation.CurrentUser,
          true);

      //Add the certificate to the FHIR client request 
      client.OnBeforeRequest += (object sender, BeforeRequestEventArgs e) =>
      {          
        e.RawRequest.ClientCertificates.Add(signingCert);        
      };

      //Make the request to GET all PractitionerRole resources
      Resource responseResource = client.Get("/PractitionerRole");

      if (responseResource is Bundle bundle)
      {
        Console.WriteLine($"Recived a {bundle.TypeName} resource containing a collection of resources as follows:");
        int counter = 1;
        foreach(var entry in bundle.Entry )
        {          
          Console.WriteLine($"Resource {counter.ToString()} is a {entry.Resource.TypeName} resource.");
          counter++;
        }

      } else
      {
        Console.WriteLine($"Not the response we were expecting!");
      }
      Console.ReadKey();      
    }

    public static X509Certificate2 GetCertificate(String findValue,
        X509FindType findType, StoreName storeName,
        StoreLocation storeLocation, bool valid)
    {
      X509Store certStore = new X509Store(storeName, storeLocation);
      certStore.Open(OpenFlags.ReadOnly);

      X509Certificate2Collection foundCerts =
        certStore.Certificates.Find(findType, findValue, valid);
      certStore.Close();

      // Check if any certificates were found with the criteria
      if (foundCerts.Count == 0)
        throw new ArgumentException("Certificate was not found with criteria '" + findValue + "'");

      // Check if more than one certificate was found with the criteria
      if (foundCerts.Count > 1)
        throw new ArgumentException("More than one certificate found with criteria '" + findValue + "'");

      return foundCerts[0];
    }

  }
}
