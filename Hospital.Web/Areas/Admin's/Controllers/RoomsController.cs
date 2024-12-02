using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using cloudscribe.Pagination.Models;
using Hospital.Repositories.Interfaces;


namespace Hospital.Web.Areas.Admin_s.Controllers
{
    [Area("Admin's")]
    public class RoomsController : Controller
    {
        private readonly IRoomServices _roomServices;
        private readonly IHospitalInfo _hospitalInfo;

        public RoomsController(IRoomServices roomServices , IHospitalInfo hospitalInfo)
        {
            _roomServices = roomServices;
            _hospitalInfo = hospitalInfo;
        }

        // GET: Room/Index
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(   _roomServices.GetAll(pageNumber, pageSize));
            
        }

        // GET: Room/Details/{id}
        public IActionResult Details(int id)
        {
            var room = _roomServices.GetRoomByID(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // GET: Room/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomViewModels vm)
        {   
               _roomServices.InsertRoom(vm);
                return RedirectToAction("Index");       
        }

        // GET: Room/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _roomServices.GetRoomByID(id);
         
            return View(viewModel);
        }

        // POST: Room/Edit/{id}
        [HttpPost]
        public IActionResult Edit( RoomViewModels vm)
        {
                _roomServices.UpdateRoom(vm);
                return RedirectToAction("Index");          
        }  
        public IActionResult Delete(int id)
        {
            _roomServices.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
