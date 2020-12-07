using System;
using System.Collections.Generic;
using System.Text;

namespace FHIRTools.R4.Common.FhirPathTools
{
  public static class CustomFhirPathResolver
  {
    public static Hl7.Fhir.ElementModel.ITypedElement Resolver(string url)
    {
      
      PyroElementNavigator PyroElementNavigator = new PyroElementNavigator();
      PyroElementNavigator.Name = "name";
      PyroElementNavigator.InstanceType = "Patient";
      PyroElementNavigator.Value = "value";
      PyroElementNavigator.Location = "location";
      string test = url;

      return PyroElementNavigator;
    }
  }
}