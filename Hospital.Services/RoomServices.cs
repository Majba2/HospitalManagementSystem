using cloudscribe.Pagination.Models; // Ensure correct namespace is used for PagedResult
using Hospital.Model;
using Hospital.Repositories;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Services
{
    public class RoomServices : IRoomServices
    {
        private IUnitOfWork _unitOfWork;

        public RoomServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();
        }

        // Use cloudscribe.Pagination.Models.PagedResult<RoomViewModels>
        public cloudscribe.Pagination.Models.PagedResult<RoomViewModels> GetAll(int pageNumber, int pageSize)
        {
            int totalCount;
            List<RoomViewModels> vmList = new List<RoomViewModels>();

            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Room>().GetAll(
                     includeProperties:"Hospital"
                    )
                    .Skip(ExcludeRecords)
                    .Take(pageSize)
                    .ToList();

                totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new cloudscribe.Pagination.Models.PagedResult<RoomViewModels>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public RoomViewModels GetRoomByID(int roomID)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(roomID);
            var vm = new RoomViewModels(model);
            return vm;
        }

        public void InsertRoom(RoomViewModels room)
        {
            var model = new RoomViewModels().ConvertViewModel(room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModels room)
        {
            var model = new RoomViewModels().ConvertViewModel(room);
            var modelByID = _unitOfWork.GenericRepository<Room>().GetById(model.ID);
            modelByID.Type = room.Type;
            modelByID.RoomName = room.RoomName;
            modelByID.Status = room.Status;
            modelByID.HospitalID = room.HospitalInfoID;
            _unitOfWork.GenericRepository<Room>().Update(modelByID);
            _unitOfWork.Save();
        }

        private List<RoomViewModels> ConvertModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModels(x)).ToList();
        }
    }
}
