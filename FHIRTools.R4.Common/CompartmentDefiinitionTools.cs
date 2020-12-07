using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;

namespace FHIRTools.R4.Common
{
  public class CompartmentDefiinitionTools
  {
    public List<CompartmentDefinition> GetDefinitionList()
    {
      var ReturnList = new List<CompartmentDefinition>();
      var Def = new DefinitionZip();
      var DefSearchBundle = Def.GetBundle(DefinitionZip.DefinitionsBundleType.ProfilesResources);
      foreach(var item in DefSearchBundle.Entry)
      {
        if (item.Resource.ResourceType == ResourceType.CompartmentDefinition)
        {
          if (item.Resource is CompartmentDefinition CompartmentDef)
          {
             ReturnList.Add(CompartmentDef);           
          }
        }
      }
      return ReturnList;
      
    }
  }
}
