using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.FhirPath;
using Hl7.FhirPath;
using Hl7.Fhir.Serialization;

namespace FHIRTools.R4.FhirPathTool
{
  public class FhirPathProcessor
  {
    public void ProcessExpression()
    {
      //string Expression = $"(AuditEvent.entity.what.value as Reference).Url";
      string Expression = $"AuditEvent.entity.what.where(resolve() is Patient)";
      //string Expression = $"AuditEvent.entity.what.reference.startsWith('Patient')";
      //string Expression = $"AuditEvent.entity.what.where(reference.startsWith('Patient/') or reference.contains('/Patient/')) | AuditEvent.agent.who.where(reference.startsWith('Patient/') or reference.contains('/Patient/'))";
      //string Expression = $"AuditEvent.entity.what.where(reference.startsWith('Patient'))";
      Console.Write($"FHIR Path Expression: {Expression}");
      FhirXmlParser FhirXmlParser = new FhirXmlParser();
      Resource Resource = FhirXmlParser.Parse<Resource>(ResourceStore.FhirResource1);      
      //Hl7.Fhir.ElementModel.PocoNavigator Navigator = new Hl7.Fhir.ElementModel.PocoNavigator(Resource);
      var TypedElement = Resource.ToTypedElement();
      try
      {

        FHIRTools.R4.Common.FhirPathTools.FhirPathProcessor FhirPathProcessor = new Common.FhirPathTools.FhirPathProcessor();
        var CompileEx = FhirPathProcessor.ParseExpression(Expression);
        

        Hl7.FhirPath.FhirPathCompiler.DefaultSymbolTable.AddFhirExtensions();
        
        var oFhirEvaluationContext = new Hl7.Fhir.FhirPath.FhirEvaluationContext(TypedElement);
        

        //The resolve() function then also needs to be provided an external resolver delegate that performs the resolve
        //that delegate can be set as below. Here I am providing my own implementation 'IPyroFhirPathResolve.Resolver' 
        oFhirEvaluationContext.ElementResolver = FHIRTools.R4.Common.FhirPathTools.CustomFhirPathResolver.Resolver;
        IEnumerable<ITypedElement> ResultList = TypedElement.Select(Expression, oFhirEvaluationContext);
        //IEnumerable<IElementNavigator> ResultList = Navigator.Select(Expression, oFhirEvaluationContext);


        
        foreach (ITypedElement oElement in ResultList)
        {
          
          if (oElement is IFhirValueProvider FhirValueProvider)
          {
            if (FhirValueProvider.FhirValue is ResourceReference Ref)
            {
              Console.WriteLine($"Found: {Ref.Url.ToString()}");
            }
            else
            {            
              Console.WriteLine($"TYpe was: {FhirValueProvider.FhirValue.GetType().ToString()}");
            }
          }
          else
          {
            Console.WriteLine();
            Console.WriteLine("No Value Found!");
          }
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
