using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FHIRTools.Stu3.Common
{
  public class FhirSpecExamplesTool
  {
    private List<Resource> _MasterResourceList;

    public List<Resource> GetSearchParameterDefinitionList()
    {
      LoadMasterList();
      return _MasterResourceList; ;
    }

    public List<T> GetResourceByType<T>() where T : Resource
    {
      LoadMasterList();
      List<T> ReturnList = new List<T>();
      string ResourceName = ModelInfo.GetFhirTypeNameForType(typeof(T));
      ResourceType? ResourceType = ModelInfo.FhirTypeNameToResourceType(ResourceName);      
      var list = _MasterResourceList.Where(x => x.ResourceType == ResourceType.Value).ToList();
      foreach(var Res in list)
      {
        if (Res is T ResType)
          ReturnList.Add(ResType);
      }
      return ReturnList;
    }

    public List<Resource> GetResourceByResourceType(ResourceType ResourceType)
    {
      LoadMasterList();           
      return _MasterResourceList.Where(x => x.ResourceType == ResourceType).ToList();
      
    }

    private void LoadMasterList()
    {
      if (_MasterResourceList == null)
      {
        _MasterResourceList = new List<Resource>();
        var ExampleZip = new ExampleZip();
        _MasterResourceList = ExampleZip.GetExamples();        
      }
    }
  }
}
