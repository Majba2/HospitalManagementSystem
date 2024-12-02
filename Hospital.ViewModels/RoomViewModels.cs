using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;

namespace Hospital.ViewModels
{
    public class RoomViewModels
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalInfoID { get; set; }
        public HospitalInfo HospitalInfo { get; set; }


        public RoomViewModels() { }
        public RoomViewModels(Room model)
        {
            ID = model.ID;
            RoomName = model.RoomName;
            Type = model.Type;
            Status = model.Status;
            HospitalInfoID = model.HospitalID;
            HospitalInfo = model.Hospital;
    }
        public Room ConvertViewModel(RoomViewModels model)
        {
            return new Room
            {
                ID = model.ID,
                RoomName = model.RoomName,
                Type = model.Type,
                Status = model.Status,
                HospitalID = model.HospitalInfoID,
                Hospital= model.HospitalInfo
                

            };
        }
    }
}
