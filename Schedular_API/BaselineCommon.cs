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
    
    public partial class BaselineCommon
    {
        public int Id { get; set; }
        public Nullable<int> BuildingFkId { get; set; }
        public string BuildingId { get; set; }
        public string ObjectDisplayName { get; set; }
        public string DataFieldDisplayName { get; set; }
        public Nullable<int> BaselineType { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string IPAddress { get; set; }
        public string AlertType { get; set; }
        public string WeekDays { get; set; }
    }
}
