using Hospital.Model;
using Hospital.ViewModels;
using System.Collections.Generic;

namespace Hospital.Repositories.Interfaces
{
    public interface IHospitalInfo
    {
        PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);
        HospitalInfoViewModel GetHospitalByID(int HospitalID);
        void InsertHospitalInfo(HospitalInfoViewModel hospitalInfo);
        void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo);
        void DeleteHospitalInfo(int ID);
        //IEnumerable<HospitalInfo> GetAll();
    }
}


