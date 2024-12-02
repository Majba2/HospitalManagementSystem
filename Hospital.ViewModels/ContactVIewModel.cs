using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class ContactVIewModel
    {
        public int ID { get; set; }
        public int HospitalID { get; set; }
        public HospitalInfo Hospital { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int HospitalInfoID { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public ContactVIewModel() { }
        public ContactVIewModel(Contact model)
        { 
          ID= model.ID;
            Email= model.Email;
            Phone= model.Phone;
            HospitalInfoID = model.HospitalID;
            HospitalInfo = model.Hospital;
        }
        public Contact ConvertViewModel(ContactVIewModel model)
        {
            return new Contact
            {
                ID = model.ID,
                Email = model.Email,
                Phone = model.Phone,
                HospitalID = model.HospitalInfoID,
                Hospital = model.HospitalInfo
            };
         
        }
    }
}
