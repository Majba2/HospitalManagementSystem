using System;

namespace Hospital.Model
{
    public class Appointment
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }

        // Foreign Keys
        public string DoctorId { get; set; }
        public string PatientId { get; set; }

        // Navigation Properties
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }
    }
}
