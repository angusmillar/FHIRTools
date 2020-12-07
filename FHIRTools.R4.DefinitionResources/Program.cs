using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FHIRTools.R4.Common;
using Hl7.Fhir.Model;

namespace FHIRTools.R4.DefinitionResources
{
  class Program
  {
    static void Main(string[] args)
    {
      //WriteDefinitionsToFile WriteDefinitionsToFile = new WriteDefinitionsToFile();
      //WriteDefinitionsToFile.Write();


      PareseToResourceType PareseToResourceType = new PareseToResourceType();
      PareseToResourceType.Process();


      Console.WriteLine("Done");
      Console.ReadKey();
    }
  }
}
