//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schedular_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class ModuleConfiguration
    {
        public int Id { get; set; }
        public int ModuleFkId { get; set; }
        public Nullable<bool> IsAlert { get; set; }
        public Nullable<bool> IsBaseline { get; set; }
        public Nullable<bool> IsReport { get; set; }
        public Nullable<bool> IsAnalytics { get; set; }
    }
}
