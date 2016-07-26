//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IqansAppsForCTS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingNew
    {
        [DisplayName("Booking Id")]
        public int BookingId { get; set; }
        [DisplayName("Room Number")]
        public string RoomNumber { get; set; }
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }
        [DisplayName("Start Time")]
        public System.TimeSpan StartTime { get; set; }
        [DisplayName("End Time")]
        public System.TimeSpan EndTime { get; set; }
        [DisplayName("Name")]
        public string EmpName { get; set; }
        [DisplayName("Email Id")]
        public string EmpId { get; set; }
        [DisplayName("Booking Time")]
        public System.DateTime BookingTime { get; set; }
        [DisplayName("Subject")]
        public string Subject { get; set; }
    }
}
