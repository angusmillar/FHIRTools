using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHIRTools.Stu3.ResourceLoader
{
  public class AuDefinition
  {
    public string FileName { get; set; }
    public string FhirId { get; set; }
    public Resource Resource { get; set; }
    public ResourceType ResourceType { get; set; }
  }
}
