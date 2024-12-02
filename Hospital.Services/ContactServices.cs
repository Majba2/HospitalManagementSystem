using Hospital.Model;
using Hospital.Repositories;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using cloudscribe.Pagination.Models;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class ContactServices : IContact
    {
        private IUnitOfWork _unitOfWork;
        public ContactServices(IUnitOfWork unitOfWork)
        {
          _unitOfWork = unitOfWork;
        }
        public void DeleteContact(int id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(id);
            _unitOfWork.GenericRepository<Contact>().Delete(model);
            _unitOfWork.Save();
        }

        public cloudscribe.Pagination.Models. PagedResult<ContactVIewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount;
            List<ContactVIewModel> vmList = new List<ContactVIewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Contact>().GetAll(
                      includeProperties: "Hospital"
                    ).
                    Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new cloudscribe.Pagination.Models.PagedResult< ContactVIewModel>

            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;

        }
        public ContactVIewModel GetContactByID(int ContactID)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(ContactID);
            var vm = new ContactVIewModel(model);
            return vm;
        }

        public void InsertContact(ContactVIewModel contact)
        {
            var model = new ContactVIewModel().ConvertViewModel(contact);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateContact(ContactVIewModel contact)
        {
            var model = new ContactVIewModel().ConvertViewModel(contact);
            var ModelByID = _unitOfWork.GenericRepository<Contact>().GetById(model.ID);
            ModelByID.Phone = contact.Phone;
            ModelByID.Email = contact.Email;
            ModelByID.HospitalID = contact.HospitalInfoID;
            _unitOfWork.GenericRepository<Contact>().Update(ModelByID);
            _unitOfWork.Save();
        }

        private List<ContactVIewModel> ConvertModelToViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactVIewModel(x)).ToList();
        }

    }
}
