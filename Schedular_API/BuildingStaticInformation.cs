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
    
    public partial class BuildingStaticInformation
    {
        public int BuildingFkId { get; set; }
        public string BuildingId { get; set; }
        public string PostalCode { get; set; }
        public Nullable<System.DateTime> DateofLastEnergyAuditSubmission { get; set; }
        public Nullable<int> NumberofGuestRooms { get; set; }
        public Nullable<System.DateTime> StarginDate { get; set; }
        public string Location { get; set; }
        public string OwnerName { get; set; }
    }
}