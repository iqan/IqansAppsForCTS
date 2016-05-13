using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IqansAppsForCTS.Models
{
    public class MeetingRoom
    {
        public string RoomNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EmpName { get; set; }
        public string Subject { get; set; }
    }
}