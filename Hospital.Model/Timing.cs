using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Timing
    {
        public int ID { get; set; }
        public ApplicationUser DoctorID { get; set; }
        public DateTime Date { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }

        public int AfterNoonShiftStartTime { get; set; }

        public int AfterNoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }


    }
}

namespace Hospital.Model
{
    public enum Status
    {
        Available , Pending,Confirm
    }
}