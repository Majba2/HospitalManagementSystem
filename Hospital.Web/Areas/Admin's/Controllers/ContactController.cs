using Hospital.Model;
using Hospital.Repositories.Interfaces;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin_s.Controllers
{
    [Area("Admin's")]
    public class ContactController : Controller
    {
        private readonly IContact _contact;
        private readonly IHospitalInfo _hospitalInfo;

        public ContactController(IContact contact, IHospitalInfo hospitalInfo)
        {
            _contact = contact;
            _hospitalInfo = hospitalInfo;
        }

        // GET: Contact/Index
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var result = _contact.GetAll(pageNumber, pageSize);
            return View(result);
        }

        // GET: Contact/Details/{id}
        public IActionResult Details(int id)
        {
            var contact = _contact.GetContactByID(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // GET: Contact/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.HospitalList = _hospitalInfo.GetAll(1, int.MaxValue).Data; // Load all hospitals
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactVIewModel vm)
        {
            if (ModelState.IsValid)
            {
                _contact.InsertContact(vm);
                return RedirectToAction("Index");
            }
            ViewBag.HospitalList = _hospitalInfo.GetAll(1, int.MaxValue).Data; // Reload hospital list if validation fails
            return View(vm);
        }

        // GET: Contact/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _contact.GetContactByID(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewBag.HospitalList = _hospitalInfo.GetAll(1, int.MaxValue).Data; // Load all hospitals
            return View(contact);
        }

        // POST: Contact/Edit/{id}
        [HttpPost]
        public IActionResult Edit(ContactVIewModel vm)
        {
            if (ModelState.IsValid)
            {
                _contact.UpdateContact(vm);
                return RedirectToAction("Index");
            }
            ViewBag.HospitalList = _hospitalInfo.GetAll(1, int.MaxValue).Data; // Reload hospital list if validation fails
            return View(vm);
        }

        // POST: Contact/Delete/{id}
        public IActionResult Delete(int id)
        {
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
