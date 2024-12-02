using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Specialist { get; set; }
        public bool IsDoctor    { get; set; }
        public string Picture { get; set; }
        public Department Department { get; set; }
     
        public ICollection<Appointment> Appointment { get; set; }
      
        public ICollection<Payroll> Payrolls { get; set; }
        public ICollection <PatientReport> PatientReports { get; set; }

    }

 
}

namespace Hospital.Model
{
    public enum Gender
    {
        Male,FeMale , Other
    }
}