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
    
    public partial class BaselineCommonDataPoint
    {
        public int Id { get; set; }
        public int BaselineCommonId { get; set; }
        public string ObjectId { get; set; }
        public int ObjectFkId { get; set; }
        public string DataFieldId { get; set; }
        public int DataFieldFkId { get; set; }
        public int ObjectNo { get; set; }
        public Nullable<double> Value { get; set; }
    }
}