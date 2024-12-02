using Hospital.Model;
using Hospital.Repositories;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Services
{
    public class HospitalInfoService : IHospitalInfo
    {
        private readonly IUnitOfWork _unitOfWork;

        public HospitalInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount;
            List<HospitalInfoViewModel> vmList = new List<HospitalInfoViewModel>();

            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<HospitalInfo>()
                    .GetAll()
                    .Skip(excludeRecords)
                    .Take(pageSize)
                    .ToList();

                totalCount = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().Count();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<HospitalInfoViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public HospitalInfoViewModel GetHospitalByID(int HospitalID)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(HospitalID);
            return new HospitalInfoViewModel(model);
        }

        public void InsertHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
            _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(hospitalInfo.ID);

            if (model != null)
            {
                model.Name = hospitalInfo.Name;
                model.Country = hospitalInfo.Country;
                model.City = hospitalInfo.City;
                model.PinCode = hospitalInfo.PinCode;

                _unitOfWork.GenericRepository<HospitalInfo>().Update(model);
                _unitOfWork.Save();
            }
        }

        public void DeleteHospitalInfo(int ID)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(ID);

            if (model != null)
            {
                _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
                _unitOfWork.Save();
            }
        }

        private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> modelList)
        {
            return modelList.Select(model => new HospitalInfoViewModel(model)).ToList();
        }
    }
}
