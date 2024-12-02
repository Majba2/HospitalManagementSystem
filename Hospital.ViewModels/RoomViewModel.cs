using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalInfoID { get; set; }

        public RoomViewModel() { }
        public RoomViewModel(Room model) 
        {
          ID = model.ID;
            RoomName = model.RoomName;
            Type = model.Type;
            Status = model.Status;
            HospitalInfoID = model.HospitalID;
        }
        public Room ConvertViewModel(RoomViewModel model)
        {
          return new Room { 
              ID = model.ID,
              RoomName = model.RoomName,
              Type = model.Type,
              Status = model.Status,
              HospitalID=model.HospitalInfoID


          };
        }
    }
}
