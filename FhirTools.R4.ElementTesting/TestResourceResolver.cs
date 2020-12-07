using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using FHIRTools.R4.Common;


namespace FhirTools.R4.ElementTesting
{
  public class TestResourceResolver : IResourceResolver
  {
    private Bundle ProfilesResourcesBundle;
    public TestResourceResolver()
    {
      var DefTool = new FHIRTools.R4.Common.DefinitionZip();
      ProfilesResourcesBundle = DefTool.GetBundle(DefinitionZip.DefinitionsBundleType.ProfilesResources);
    }

    public Resource ResolveByCanonicalUri(string uri)
    {
      return ProfilesResourcesBundle.Entry.SingleOrDefault(x => x.FullUrl == uri).Resource;      
    }

    public Resource ResolveByUri(string uri)
    {
      return ProfilesResourcesBundle.Entry.SingleOrDefault(x => x.FullUrl == uri).Resource;      
    }
  }
}
