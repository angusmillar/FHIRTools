using System;
using System.Xml;
using System.IO;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.FhirPath;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification;
using System.Linq;
using System.Text;

namespace FhirTools.R4.ElementTesting
{
  class Program
  {
    static void Main(string[] args)
    {
      var xml = "<Patient xmlns=\"http://hl7.org/fhir\"><identifier>" +
     "<use value=\"official\" /></identifier></Patient>";
      MemoryStream memStream = new MemoryStream();
      byte[] data = Encoding.Default.GetBytes(xml);
      memStream.Write(data, 0, data.Length);
      memStream.Position = 0;
      XmlReader reader = XmlReader.Create(memStream);
      reader.Read();

      FhirXmlParsingSettings settings = new FhirXmlParsingSettings();

      ISourceNode patientNode = FhirXmlNode.Read(reader, settings);
      //IResourceResolver Resolver = new TestResourceResolver();
      IResourceResolver Resolver = ZipSource.CreateValidationSource();


      StructureDefinitionSummaryProvider Provider = new StructureDefinitionSummaryProvider(Resolver);



      ITypedElement patientRootElement = patientNode.ToTypedElement(Provider);

      var r = patientRootElement.Select("Patient.identifier.use");
      string test = (string)r.FirstOrDefault().Value;

      //ITypedElement activeElement = patientRootElement.Children("active").First();
      //Assert.AreEqual("boolean", activeElement.Type);

      //Assert.AreEqual("boolean", activeElement.Type);


      //var patientNode = FhirXmlNode.Parse(xml);
      //var use = patientNode.Children("identifier").Children("use").First();
      //Assert.AreEqual("official", use.Text);
      //Assert.AreEqual("Patient.identifier[0].use[0]", use.Location);
    }
  }
}
