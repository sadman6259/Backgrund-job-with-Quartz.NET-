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
    
    public partial class ReportTable
    {
        public int Id { get; set; }
        public Nullable<int> BuildingFkId { get; set; }
        public string ParameterName { get; set; }
        public string TableName { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public string Unit { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<double> Value { get; set; }
        public string ParamterDisplayName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> UserFkId { get; set; }
        public string ReportType { get; set; }
    }
}
