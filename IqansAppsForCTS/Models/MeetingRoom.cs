using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IqansAppsForCTS.Models
{
    public class MeetingRoom
    {
        [DisplayName("Room Number")]
        public string RoomNumber { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        [DisplayName("Employee Name")]
        public string EmpName { get; set; }
        [DisplayName("Subject")]
        public string Subject { get; set; }
    }
}