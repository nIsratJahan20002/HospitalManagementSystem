using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Models.HMS
{
    public class GetScheduleCreate
    {
        public int ScheduleId { get; set; }
        public string DoctorName { get; set; }
        public string HospitalName { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public int Active { get; set; }
    }
}