using System;
using Hugolf.Data;
using Hugolf.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hugolf.Controllers;

public class MembershipController : Controller
{
    private readonly ApplictionDbContext _db;

    public MembershipController(ApplictionDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Membership> membershipList = _db.Memberships.ToList();
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
            _db.Memberships.Add(obj);
            _db.SaveChanges();
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
        Membership? membershipFromDb = _db.Memberships.Find(id);
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
            _db.Memberships.Update(obj);
            _db.SaveChanges();
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
        Membership? membershipFromDb = _db.Memberships.Find(id);
        if (membershipFromDb == null)
        {
            return NotFound();
        }
        return View(membershipFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Membership? membershipFromDb = _db.Memberships.Find(id);
        if (membershipFromDb == null)
        {
            return NotFound();
        }
        _db.Memberships.Remove(membershipFromDb);
        _db.SaveChanges();
        TempData["success"] = "Membership deleted successfully";
        return RedirectToAction("Index");
    }
}
