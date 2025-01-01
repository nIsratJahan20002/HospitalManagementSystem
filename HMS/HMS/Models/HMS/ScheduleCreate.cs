using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Models.HMS
{
    public class ScheduleCreate
    {
        public int DoctorId { get; set; }
        public int HospitalId { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public int Active { get; set; }
    }
}