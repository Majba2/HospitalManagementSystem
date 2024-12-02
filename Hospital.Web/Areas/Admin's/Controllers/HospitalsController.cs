using cloudscribe.Pagination.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin_s.Controllers
{
    [Area("Admin's")]
    public class HospitalsController : Controller
    {
    
        private IHospitalInfo _hospitalInfo;

        public HospitalsController(IHospitalInfo hospitalInfo)
        {
            _hospitalInfo = hospitalInfo;
        }

        public IActionResult Index(int pageNumber=1 , int pageSize = 10)
        {
            return View(_hospitalInfo.GetAll(pageNumber,pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospitalInfoViewModel vm)
        {
            _hospitalInfo.InsertHospitalInfo(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var viewModel = _hospitalInfo.GetHospitalByID(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(HospitalInfoViewModel vm)
        {
             _hospitalInfo.UpdateHospitalInfo(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            _hospitalInfo.DeleteHospitalInfo(id);
            return RedirectToAction("Index");
         }
    }
}
