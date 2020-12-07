using System;
using System.Collections.Generic;
using FHIRTools.R4.Common;
using Hl7.Fhir.Model;
using System.Linq;
using Hl7.Fhir.Utility;

namespace FHIRTools.R4.CompartmentResourceGenerator
{
  class Program
  {
    static void Main(string[] args)
    {
      var SearchParamTool = new SearchParameterTools();
      var CompartemntDefTool = new CompartmentDefiinitionTools();


      List<CompartmentDefinition> CompartmentDefList = CompartemntDefTool.GetDefinitionList();

      foreach (var Compartment in CompartmentDefList)
      {
        ResourceType ResType = GetResourceTypeForCompartmentCode(Compartment.Code.Value);
        Console.WriteLine($"Compartment: {ResType.GetLiteral()}");
        Console.WriteLine($"===========================================================");
        if (ResType == ResourceType.AuditEvent)
        {

        }
        //List<SearchParameter> CompartmentSearchParameterList = SearchParamTool.GetSearchParameterDefinitionListForResource(ResType);
        foreach (var ResComponent in Compartment.Resource)
        {
          Console.WriteLine($"Resource: {ResComponent.Code.GetLiteral()}");
          List<SearchParameter> SearchParameterForResourceList = SearchParamTool.GetSearchParameterDefinitionListForResource(ResComponent.Code.Value);
          foreach(string Param in ResComponent.Param)
          {
            var SearchParameter = SearchParameterForResourceList.SingleOrDefault(x => x.Name == Param);
            if (SearchParameter != null)
            {
              Console.WriteLine($"Search Param: {SearchParameter.Name}");
              if (SearchParameter.Type == SearchParamType.Reference)
              {
                if (SearchParameter.Target != null)
                {
                  if (SearchParameter.Target.Count() > 1)
                  {
                    if (SearchParameter.Target.Contains(ResType))
                    {

                    }
                  }
                  else
                  {

                  }
                }
              }
            }
          }
        }
        
        

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
