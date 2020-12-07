using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace FHIRTools.Stu3.ResourceLoader
{
  public class AuDefinitionsDownLoader
  {
    private string definitionUrl = "http://build.fhir.org/ig/hl7au/au-fhir-base/definitions.xml.zip";
    public List<AuDefinition> GetResourceList()
    {
      List<AuDefinition> AuDefinitionList = new List<AuDefinition>();
      HttpClient downloader = new HttpClient();
      Stream stream = null;      
      stream = downloader.GetStreamAsync(definitionUrl).Result;      
      using (ZipInputStream s = new ZipInputStream(stream))
      {
        ZipEntry entry;        
        while ((entry = s.GetNextEntry()) != null)
        {          
          if (entry.Name.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase))
          {

            //Console.WriteLine($"Modified: {entry.DateTime.ToShortDateString()} {entry.DateTime.ToShortTimeString()}");
            if (entry.IsFile)
            {         
              var buffer = new MemoryStream();
              s.CopyTo(buffer);
              buffer.Seek(0, SeekOrigin.Begin);
              var sr = SerializationUtil.XmlReaderFromStream(buffer);
              Resource resource = new Hl7.Fhir.Serialization.FhirXmlParser().Parse<Resource>(sr);
              
              AuDefinition AuDef = new AuDefinition();
              AuDef.FileName = entry.Name;
              AuDef.FhirId = resource.Id;
              AuDef.ResourceType = resource.ResourceType;
              AuDef.Resource = resource;

              AuDefinitionList.Add(AuDef);
              Console.WriteLine("Resource File Name : {0}", entry.Name);              
            }
          }
        }

        // Close can be ommitted as the using statement will do it automatically
        // but leaving it here reminds you that is should be done.
        s.Close();
      }
      
      return AuDefinitionList;

    }

  }
}
