﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FHIRTools.R4.FhirPathTool {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourceStore {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceStore() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FHIRTools.R4.FhirPathTool.ResourceStore", typeof(ResourceStore).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;AuditEvent xmlns=&quot;http://hl7.org/fhir&quot;&gt;
        ///    &lt;id value=&quot;fabeaf37-c2bc-4b3d-a88e-433c0b276df1&quot; /&gt;
        ///    &lt;meta&gt;
        ///        &lt;versionId value=&quot;1&quot; /&gt;
        ///        &lt;lastUpdated value=&quot;2018-09-17T15:22:31.474+08:00&quot; /&gt;
        ///        &lt;tag&gt;
        ///            &lt;system value=&quot;https://pyrohealth.net/fhir/CodeSystem/pyrofhirserver&quot; /&gt;
        ///            &lt;code value=&quot;Protected&quot; /&gt;
        ///            &lt;display value=&quot;Protected Resource&quot; /&gt;
        ///        &lt;/tag&gt;
        ///    &lt;/meta&gt;
        ///    &lt;text&gt;
        ///        &lt;div xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
        ///            &lt;div&gt;
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FhirResource1 {
            get {
                return ResourceManager.GetString("FhirResource1", resourceCulture);
            }
        }
    }
}