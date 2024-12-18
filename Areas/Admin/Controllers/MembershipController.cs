using System;
using Hugolf.Data;
using Hugolf.Models;
using Hugolf.Repository;
using Hugolf.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Hugolf.Controllers;

[Area("Admin")]
public class MembershipController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public MembershipController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Membership> membershipList = _unitOfWork.Membership.GetAll().ToList();
        return View(membershipList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Membership obj)
    {
        // ModelState.Remove("Description");
        // ModelState.Remove("Condition");
        if (ModelState.IsValid)
        {
            _unitOfWork.Membership.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Membership created successfully!";

            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Membership? membershipFromDb = _unitOfWork.Membership.Get(u => u.Id == id);
        if (membershipFromDb == null)
        {
            return NotFound();
        }
        return View(membershipFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Membership obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Membership.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Membership updated successfully!";

            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Membership? membershipFromDb = _unitOfWork.Membership.Get(u => u.Id == id);
        if (membershipFromDb == null)
        {
            return NotFound();
        }
        return View(membershipFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Membership? membershipFromDb = _unitOfWork.Membership.Get(u => u.Id == id);
        if (membershipFromDb == null)
        {
            return NotFound();
        }
        _unitOfWork.Membership.Remove(membershipFromDb);
        _unitOfWork.Save();
        TempData["success"] = "Membership deleted successfully";
        return RedirectToAction("Index");
    }
}
