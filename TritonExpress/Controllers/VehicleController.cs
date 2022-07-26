using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TritonExpress.Data;
using TritonExpress.Models;

namespace TritonExpress.Controllers
{
    public class VehicleController : Controller
    {
        private readonly TritoExpressContext _context;

        public VehicleController(TritoExpressContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Vehicle> cars = _context.Vehicles.ToList();
            return View(cars);
        }

        //-------------------------------VIEW VEHICLE DETAILS-------------------
        public IActionResult Details(int Id)
        {
            Vehicle vehicle = _context.Vehicles.Where(p => p.VehicleId == Id).FirstOrDefault();
            return View(vehicle);
        }

        //-------------------------------EDIT VEHICLE--------------------------
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Vehicle vehicle = _context.Vehicles.Where(p => p.VehicleId == Id).FirstOrDefault();
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            _context.Attach(vehicle);
            _context.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        //-------------------------------DELETE VEHICLE--------------------------
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Vehicle vehicle = _context.Vehicles.Where(p => p.VehicleId == Id).FirstOrDefault();
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Delete(Vehicle vehicle)
        {
            _context.Attach(vehicle);
            _context.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        //-------------------------------CREATE VEHICLE--------------------------
        [HttpGet]
        public IActionResult Create()
        {
                Vehicle vehicle = new Vehicle();
                return View(vehicle);
        }
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            _context.Attach(vehicle);
            _context.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}