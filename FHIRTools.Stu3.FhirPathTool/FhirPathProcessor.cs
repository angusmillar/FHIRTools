using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.FhirPath;
using Hl7.FhirPath;
using Hl7.Fhir.Serialization;

namespace FHIRTools.Stu3.FhirPathTool
{
  public class FhirPathProcessor
  {
  
   public void ProcessExpression()
    {
      //string Expression = $"(AuditEvent.entity.what.value as Reference).Url";
      string Expression = $"AuditEvent.agent.who.where(resolve() is Patient)";
      //string Expression = $"AuditEvent.entity.where(resolve() is Patient)";
      //string Expression = $"AuditEvent.entity.what.where(reference.startsWith('Patient/') or reference.contains('/Patient/')) | AuditEvent.agent.who.where(reference.startsWith('Patient/') or reference.contains('/Patient/'))";                           
      //string Expression = $"AuditEvent.agent.who(reference.startsWith('Patient'))";
      Console.Write($"FHIR Path Expression: {Expression}");
      FhirXmlParser FhirXmlParser = new FhirXmlParser();
      Resource Resource = FhirXmlParser.Parse<Resource>(ResourceStore.AuditEvent1);      
      PocoNavigator Navigator = new PocoNavigator(Resource);
      try
      {
        IEnumerable<IElementNavigator> ResultList = Navigator.Select(Expression, new EvaluationContext(Navigator));

        bool FoundValue = false;
        foreach (IElementNavigator oElement in ResultList)
        {
          FoundValue = true;
          if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
          {
            Console.WriteLine();
            if (Poco.FhirValue is ResourceReference Ref)
            {
              Console.Write($"Found: {Ref.Url.ToString()}");
            }
            else
            {              
              Console.Write($"Found: {Poco.Value.ToString()}");
            }
          }
        }
        if (!FoundValue)
        {
          Console.WriteLine();
          Console.WriteLine("No Value Found!");
        }
          
      }
      catch(Exception Exec)
      {
        Console.WriteLine();
        Console.WriteLine($"Error Message: {Exec.Message}");
      }
    }
  }
}
