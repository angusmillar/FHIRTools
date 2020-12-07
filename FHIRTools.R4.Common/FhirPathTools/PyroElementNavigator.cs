using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace FHIRTools.R4.Common.FhirPathTools
{
  public class PyroElementNavigator : ITypedElement
  {
    public string Name { get; set; }

    public string InstanceType { get; set; }

    public object Value { get; set; }

    public string Location { get; set; }

    public IElementDefinitionSummary Definition { get; set; }

    public IEnumerable<ITypedElement> Children(string name = null)
    {
      throw new NotImplementedException();
    }
  }
}
