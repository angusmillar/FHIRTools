using FHIRTools.R4.Common;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FHIRTools.R4.DefinitionResources
{
  public class WriteDefinitionsToFile
  {
    public void Write()
    {
      string FilePath = @"C:\temp\DefinitionResources.txt";
      StringBuilder sb = new StringBuilder();


      DefinitionZip DefZip = new DefinitionZip();
      List<Resource> AllDefResourceList = DefZip.GetAll();
      foreach (var Res in AllDefResourceList)
      {
        string OutPut = $"Resource: {Res.ResourceType.ToString()}, Id: {Res.Id}";
        Console.WriteLine(OutPut);
        sb.AppendLine(OutPut);
      }

      Console.WriteLine($"Total: {AllDefResourceList.Count}");
      sb.AppendLine($"Total: {AllDefResourceList.Count}");

      File.WriteAllText(FilePath, sb.ToString());
      Console.WriteLine("Done");
      Console.ReadKey();
    }
  }
}
