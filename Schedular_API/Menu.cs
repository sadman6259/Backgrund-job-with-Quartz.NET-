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
    
    public partial class Menu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuDisplayName { get; set; }
        public string Url { get; set; }
        public string IconClass { get; set; }
        public int ParentId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string ObjectId { get; set; }
    }
}