using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FHIRTools.R4.Common
{
  public class DefinitionZip
  {

    private List<Resource> _MainResourceList;

    public enum DefinitionsBundleType
    {
      ConceptMaps,
      SearchParameters,
      DataElements,
      ExtensionDefinitions,
      ProfilesOthers,
      ProfilesResources,
      ProfilesTypes,
      V2Tables,
      V3CodeSystems,
      ValueSets
    };

    public List<Resource> GetAll()
    {
      if (_MainResourceList == null)
      {
        LoadAll();
      }
      return _MainResourceList;
    }

    private void LoadAll()
    {
      _MainResourceList = new List<Resource>();
      var DefinitionsBundleTypeList = Enum.GetValues(typeof(DefinitionsBundleType)).Cast<DefinitionsBundleType>();
      foreach (var DefType in DefinitionsBundleTypeList)
      {
        Bundle Bun = GetBundle(DefType);
        foreach (var Entry in Bun.Entry)
        {
          _MainResourceList.Add(Entry.Resource);
        }
      }

    }

    public Bundle GetBundle(DefinitionsBundleType DefinitionsBundleType)
    {
      return LoadFromZip(DefinitionsBundleType);
    }

    public List<Resource> GetResourceList(DefinitionsBundleType DefinitionsBundleType)
    {
      Bundle Bundle = LoadFromZip(DefinitionsBundleType);
      var returnList = new List<Resource>();
      foreach(var Entry in Bundle.Entry)
      {
        returnList.Add(Entry.Resource);
      }
      return returnList;
    }

    private Bundle LoadFromZip(DefinitionsBundleType DefinitionBundleType)
    {
      Stream FileStream = new MemoryStream(ResourceStore.definitions_xml);
      using (ZipArchive Archive = new ZipArchive(FileStream))
      {
        foreach (ZipArchiveEntry Entry in Archive.Entries)
        {

          if (Entry.FullName.Equals(GetFileNameForType(DefinitionBundleType), StringComparison.OrdinalIgnoreCase))
          {
            //Pick processing from where it was last left off
            Stream StreamItem = Entry.Open();
            using (StreamItem)
            {
              var buffer = new MemoryStream();
              StreamItem.CopyTo(buffer);
              buffer.Seek(0, SeekOrigin.Begin);
              System.Xml.XmlReader XmlReader = SerializationUtil.XmlReaderFromStream(buffer);
              Resource Resource = DeSerializeFromXml(XmlReader);
              if (Resource is Bundle Bundle)
              {
                return Bundle;
              }
            }
          }
        }
      }
      return null;
    }

    private string GetFileNameForType(DefinitionsBundleType Type)
    {
      switch (Type)
      {
        case DefinitionsBundleType.ConceptMaps:
          return "conceptmaps.xml";
        case DefinitionsBundleType.SearchParameters:
          return "search-parameters.xml";
        case DefinitionsBundleType.DataElements:
          return "dataelements.xml";
        case DefinitionsBundleType.ExtensionDefinitions:
          return "extension-definitions.xml";
        case DefinitionsBundleType.ProfilesOthers:
          return "profiles-others.xml";
        case DefinitionsBundleType.ProfilesResources:
          return "profiles-resources.xml";
        case DefinitionsBundleType.ProfilesTypes:
          return "profiles-types.xml";
        case DefinitionsBundleType.V2Tables:
          return "v2-tables.xml";
        case DefinitionsBundleType.V3CodeSystems:
          return "v3-codesystems.xml";
        case DefinitionsBundleType.ValueSets:
          return "valuesets.xml";
        default:
          return "Error!!";
      }
    }

    private Resource DeSerializeFromXml(System.Xml.XmlReader XmlReader)
    {
      Hl7.Fhir.Serialization.FhirXmlParser FhirXmlParser = new Hl7.Fhir.Serialization.FhirXmlParser();
      return FhirXmlParser.Parse<Resource>(XmlReader);
    }

  }
}
