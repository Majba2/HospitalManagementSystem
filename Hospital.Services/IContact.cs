using Hospital.Repositories;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IContact
    {
        cloudscribe.Pagination.Models.PagedResult<ContactVIewModel> GetAll(int pageNumber, int pageSize);
        ContactVIewModel GetContactByID(int ContactID);
        void UpdateContact(ContactVIewModel contact);
        void InsertContact(ContactVIewModel contact);
        void DeleteContact(int ID);
    }
}
