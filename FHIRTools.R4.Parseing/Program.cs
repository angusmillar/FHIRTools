using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace FHIRTools.R4.Parseing
{
  class Program
  {
    static void Main(string[] args)
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient("http://ohcconnect.myhealthpoc.com:9093/org1", false);
      //Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient("https://r4.test.pyrohealth.net/fhir", false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      try 
      {
        var res = clientFhir.Get("Patient/8b2179c6-811d-492a-9c8e-6856be319af3");
      }
      catch(Exception exec)
      {
        string m = exec.Message;
      }
      

      //string PatientResourceId = string.Empty;

      ////Add a Patient resource by Update
      //Patient PatientOne = new Patient();
      //PatientOne.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));
      //PatientOne.BirthDateElement = new Date("1979-09-30");
      //string PatientOneMRNIdentifer = Guid.NewGuid().ToString();
      //PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));
      //PatientOne.Gender = AdministrativeGender.Unknown;

      //Patient PatientResult = null;
      //try
      //{
      //  PatientResult = clientFhir.Create(PatientOne);
      //}
      //catch (Exception Exec)
      //{
      //  Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      //}
      //Assert.NotNull(PatientResult, "Resource create by Updated returned resource of null");
      //PatientResourceId = PatientResult.Id;
      //PatientResult = null;




      var Dev = new Device();
      Dev.Property = new List<Device.PropertyComponent>();
      var TestProp = new Device.PropertyComponent();
      Dev.Property.Add(TestProp);
      TestProp.Type = new CodeableConcept();
      TestProp.Type.Coding = new List<Coding>();
      TestProp.Type.Coding.Add(new Coding()
      {
        System = "urn:iso:std:iso:11073:10101",
        Code = "68221"
      });
      TestProp.Type.Text = "MDC_TIME_SYNC_ACCURACY: null";
      TestProp.ValueQuantity = new List<Quantity>();
      TestProp.ValueQuantity.Add(new Quantity()
      {
        Value = 120000000,
        Code = "us"
      });

      FhirJsonSerializer FhirJsonSerializer = new FhirJsonSerializer();
      string JasonDevice = FhirJsonSerializer.SerializeToString(Dev, Hl7.Fhir.Rest.SummaryType.False);
      //FhirJsonSerializer.Serialize(Resource, jsonwriter, Summary);

    }
  }
}
