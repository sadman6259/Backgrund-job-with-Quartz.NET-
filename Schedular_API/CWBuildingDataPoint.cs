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
    
    public partial class CWBuildingDataPoint
    {
        public int Id { get; set; }
        public Nullable<int> BuildingFkId { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Sensor { get; set; }
        public Nullable<int> DeviceFkId { get; set; }
        public string TableName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string DisplayName { get; set; }
    }
}
