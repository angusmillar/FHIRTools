using System;
using System.Collections.Generic;
using System.IO;

namespace FHIRTools.Stu3.TextGenerator
{
  class Program
  {
    static void Main(string[] args)
    {
      // Write the string array to a new file named "WriteLines.txt".
      List<string> StringList = new List<string>();
      foreach (var ResourceName in Hl7.Fhir.Model.ModelInfo.SupportedResources)
      {
        StringList.Add($"UPDATE [dbo].[{ResourceName}Res] SET [Resource] = COMPRESS([XmlBlob]) WHERE [XmlBlob] is not null" + System.Environment.NewLine);
      }

      string Dir = @"C:\Temp";
      using (StreamWriter outputFile = new StreamWriter(Path.Combine(Dir, "FhirText.txt")))
      {
        foreach (string line in StringList)
          outputFile.Write(line);
      }


    }
  }
}
