//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagmentSytem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservations
    {
        public int reservation_id { get; set; }
        public int client_id { get; set; }
        public int room_id { get; set; }
        public Nullable<System.DateTime> check_in_date { get; set; }
        public Nullable<System.DateTime> check_out_date { get; set; }
        public string deposit_type { get; set; }
        public Nullable<decimal> total_amount { get; set; }
        public Nullable<bool> is_paid { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Rooms Rooms { get; set; }
    }
}
