using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IqansAppsForCTS.Models
{
    public class MeetingRoom
    {
        [DisplayName("Booking Id")]
        public string BookingId { get; set; }
        [Required]
        [DisplayName("Room Number")]
        public string RoomNumber { get; set; }
        [Required]
        [DisplayName("Start Date and Time")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [DisplayName("End Date and Time")]
        public DateTime EndDateTime { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string EmpName { get; set; }
        [Required]
        [DisplayName("Employee Id")]
        public int EmpId { get; set; }
        [DisplayName("Subject")]
        public string Subject { get; set; }
        [DisplayName("Booking Time")]
        public DateTime Bookingtime { get; set; }
    }
}