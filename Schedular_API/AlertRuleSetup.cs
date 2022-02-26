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
    
    public partial class AlertRuleSetup
    {
        public int Id { get; set; }
        public Nullable<int> BuildingFkId { get; set; }
        public string BuildingId { get; set; }
        public string ObjectDisplayName { get; set; }
        public string DataFieldDisplayName { get; set; }
        public Nullable<int> Severity { get; set; }
        public Nullable<double> Value { get; set; }
        public Nullable<int> Condition { get; set; }
        public Nullable<double> ReferenceValue { get; set; }
        public string DateRange { get; set; }
        public Nullable<int> AveragingWindow { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<bool> IsEmail { get; set; }
        public Nullable<bool> IsSMS { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string IPAddress { get; set; }
        public Nullable<int> ValueComingFromFlag { get; set; }
        public Nullable<double> CustomValue { get; set; }
        public string AlertText { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> FixedRulebyBCA { get; set; }
        public Nullable<int> DataComingFromReadingOrTempReading { get; set; }
        public Nullable<int> SummaryNotification { get; set; }
        public string AlertType { get; set; }
        public string WeekDays { get; set; }
        public Nullable<int> AlertRuleTypeId { get; set; }
        public Nullable<int> Interval { get; set; }
        public Nullable<int> Occurance { get; set; }
        public Nullable<int> GreenMarkInterval { get; set; }
        public Nullable<int> GreenMarkCondition { get; set; }
        public string Period { get; set; }
        public string SendTo { get; set; }
    }
}
