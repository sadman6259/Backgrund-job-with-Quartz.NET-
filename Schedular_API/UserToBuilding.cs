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
    
    public partial class UserToBuilding
    {
        public int Id { get; set; }
        public Nullable<int> UserFkId { get; set; }
        public Nullable<int> BuildingFkId { get; set; }
    }
}