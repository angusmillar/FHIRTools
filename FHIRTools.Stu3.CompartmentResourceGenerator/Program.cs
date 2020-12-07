using System;
using System.Collections.Generic;
using FHIRTools.Stu3.Common;
using Hl7.Fhir.Model;

namespace FHIRTools.Stu3.CompartmentResourceGenerator
{
  class Program
  {
    static void Main(string[] args)
    {
      var SearchParamTool = new SearchParameterTools();
      var CompartemntDefTool = new CompartmentDefiinitionTools();

      
      List<CompartmentDefinition> CompartmentDefList = CompartemntDefTool.GetDefinitionList();
      
      foreach(var Compartment in CompartmentDefList)
      {
        ResourceType ResType = GetResourceTypeForCompartmentCode(Compartment.Code.Value);        
        List<SearchParameter> SearchParameterList = SearchParamTool.GetSearchParameterDefinitionListForResource(ResType);

      }
    }

    private static ResourceType GetResourceTypeForCompartmentCode(CompartmentType Code)
    {
      switch (Code)
      {
        case CompartmentType.Patient:
          return ResourceType.Patient;
        case CompartmentType.Encounter:
          return ResourceType.Encounter;
        case CompartmentType.RelatedPerson:
          return ResourceType.RelatedPerson;
        case CompartmentType.Practitioner:
          return ResourceType.Practitioner;
        case CompartmentType.Device:
          return ResourceType.Device;
        default:
          throw new Exception("No Resource Type for CompartmentType");
      }
    }
  }
}
