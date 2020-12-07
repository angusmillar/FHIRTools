using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FHIRTools.R4.Common
{
  public class SearchParameterTools
  {
    private List<SearchParameter> MasterList;
    public SearchParameterTools()
    {      
    }

    public List<SearchParameter> GetSearchParameterDefinitionList()
    {
      if (MasterList == null)
      {
        LoadAll();
      }
      return MasterList;      
    }

    private void LoadAll()
    {
      MasterList = new List<SearchParameter>();
      var Def = new DefinitionZip();
      var DefSearchBundle = Def.GetBundle(DefinitionZip.DefinitionsBundleType.SearchParameters);
      foreach (var item in DefSearchBundle.Entry)
      {
        if (item.Resource is SearchParameter SearchParam)
        {
          MasterList.Add(SearchParam);
        }
      }      
    }

    public List<SearchParameter> GetSearchParameterDefinitionListForResource(ResourceType ResourceType)
    {
      if (MasterList == null)
      {
        LoadAll();
      }
      var ReturnList = MasterList.Where(x => x.Base.Contains(ResourceType));
      return ReturnList.ToList();
      
    }


  }
}
