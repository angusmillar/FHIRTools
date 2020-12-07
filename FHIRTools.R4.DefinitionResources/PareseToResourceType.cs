using FHIRTools.R4.Common;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FHIRTools.R4.DefinitionResources
{
  public class PareseToResourceType
  {
    public void Process()
    {
      DefinitionZip DefZip = new DefinitionZip();
      var DefBundle = DefZip.GetBundle(DefinitionZip.DefinitionsBundleType.ExtensionDefinitions);
      foreach(var Entry in DefBundle.Entry)
      {
        if (Entry.Resource is StructureDefinition StruDef)
        {
          Console.WriteLine($"Pasre OK id {Entry.Resource.Id}");
        }
        else
        {
          Console.WriteLine($"Unable to Pasre id {Entry.Resource.Id}");
        }
      }
    }
  }
}
