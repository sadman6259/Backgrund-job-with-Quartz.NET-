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
    
    public partial class AlertProccessingTrack
    {
        public int Id { get; set; }
        public int BuildingFkId { get; set; }
        public int ObjectFkId { get; set; }
        public int DataFieldFkId { get; set; }
        public Nullable<System.DateTime> LastProcessDate { get; set; }
    }
}
