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
    
    public partial class BillMapping
    {
        public int Id { get; set; }
        public Nullable<int> BuildingFkId { get; set; }
        public string BillType { get; set; }
        public Nullable<int> BillParamFkId { get; set; }
        public string Type { get; set; }
        public string Keys { get; set; }
        public string Value { get; set; }
        public string Position { get; set; }
        public string SplitBy { get; set; }
        public string SplitPosition { get; set; }
        public string RemoveString { get; set; }
        public string ReturnFormat { get; set; }
    }
}
