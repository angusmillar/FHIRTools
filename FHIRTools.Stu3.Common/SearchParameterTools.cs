using Hl7.Fhir.Model;
using System.Collections.Generic;
using System.Linq;

namespace FHIRTools.Stu3.Common
{
  public class SearchParameterTools
  {
    private List<SearchParameter> _MasterList;

    public List<SearchParameter> GetSearchParameterDefinitionList()
    {
      LoadMasterList();
      return _MasterList; ;
    }
   
    public List<SearchParameter> GetSearchParameterDefinitionListForResource(ResourceType ResourceType)
    {
      LoadMasterList();
      return _MasterList.Where(x => x.Base.Any(c => c.Value == ResourceType)).ToList();     
    }

    private void LoadMasterList()
    {
      if (_MasterList == null)
      {
        _MasterList = new List<SearchParameter>();
        var Def = new DefinitionZip();
        var DefSearchBundle = Def.GetBundle(DefinitionZip.DefinitionsBundleType.SearchParameters);
        foreach (var item in DefSearchBundle.Entry)
        {
          if (item.Resource is SearchParameter SearchParam)
          {
            _MasterList.Add(SearchParam);
          }
        }
      }
    }

  }
}
