using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IqansAppsForCTS.Models
{
    public class Resources
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ResourceName { get; set; }
        public string BillingPeriod { get; set; }
        public int Rate { get; set; }
        public int Leaves { get; set; }
        public int BillingDays { get; set; }
        public int TotalBilling { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}