using Hugolf.Models;
using Hugolf.Repository.IRepository;
using Hugolf.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hugolf.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CourseStatusController : Controller
    {
        // GET: CourseStatusController
        private readonly IUnitOfWork _unitOfWork;

        public CourseStatusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            List<CourseStatus> courseStatusesList = _unitOfWork.CourseStatus.GetAll().ToList();
            return View(courseStatusesList);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CourseStatus? courseStatusFromDb = _unitOfWork.CourseStatus.Get(u => u.Id == id);
            if (courseStatusFromDb == null)
            {
                return NotFound();
            }
            return View(courseStatusFromDb);
        }

        [HttpPost]
        public IActionResult Edit(CourseStatus obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CourseStatus.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CourseStatus updated successfully!";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
