using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace FHIRTools.R4.Common
{
  public class ExampleZip
  {  
    public List<Resource> GetExamples()
    {
      return LoadFromZip();
    }

    private List<Resource> LoadFromZip()
    {
      List<Resource> ResourceList = new List<Resource>();
      Stream FileStream = new MemoryStream(ResourceStore.examples);
      using (ZipArchive Archive = new ZipArchive(FileStream))
      {
        foreach (ZipArchiveEntry Entry in Archive.Entries)
        {
          if (ProcessFileName(Entry.FullName))
          {
            if (Entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
              Console.WriteLine($"Filename: {Entry.FullName}");
              //Pick processing from where it was last left off
              Stream StreamItem = Entry.Open();
              using (StreamItem)
              {

                var buffer = new MemoryStream();
                StreamItem.CopyTo(buffer);
                buffer.Seek(0, SeekOrigin.Begin);
                System.Xml.XmlReader XmlReader = SerializationUtil.XmlReaderFromStream(buffer);
                Resource Resource = DeSerializeFromXml(XmlReader);
                ResourceList.Add(Resource);
              }
            }
          }
        }
      }
      return ResourceList;
    }

    private bool ProcessFileName(string Filename)
    {
      if (Filename.EndsWith("observation-decimal(decimal).xml", StringComparison.OrdinalIgnoreCase))
      {
        return false;
      }
      if (Filename.EndsWith("v2-tables.xml", StringComparison.OrdinalIgnoreCase))
      {
        return false;
      }
      return true;
    }

    private Resource DeSerializeFromXml(System.Xml.XmlReader XmlReader)
    {
      Hl7.Fhir.Serialization.FhirXmlParser FhirXmlParser = new Hl7.Fhir.Serialization.FhirXmlParser();
      return FhirXmlParser.Parse<Resource>(XmlReader);
    }

  }
}
