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
    
    public partial class GasBillParameter
    {
        public int Id { get; set; }
        public Nullable<int> BuildingFkId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Nullable<int> MaxDecimalPoints { get; set; }
        public string ReturnFormat { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string TablePosition { get; set; }
        public string BillType { get; set; }
    }
}
