using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParksAPI.Models;

namespace ParksAPI.Controllers
{
  public class ParksController : Controller
  {
    public IActionResult Index()
    {
      var allParks = Park.GetParks();
      return View(allParks);
    }

    [HttpPost]
    public async Task<IActionResult> Index(Park park)
    {
      await Park.Post(park);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var park = Park.GetDetails(id);
      return View(park);
    }

    public IActionResult Edit(int id)
    {
      var park = Park.GetDetails(id);
      return View(park);
    }

    [HttpPost]
    public async Task<IActionResult> Details(int id, Park park)
    {
      park.ParkId = id;
      await Park.Put(park);
      return RedirectToAction("Details", id);
    }

    public async Task<IActionResult> Delete(int id)
    {
      await Park.Delete(id);
      return RedirectToAction("Index");
    }
  }
}