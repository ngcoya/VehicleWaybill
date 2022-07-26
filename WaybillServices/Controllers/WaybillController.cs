using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaybillServices.Data;
using WaybillServices.Models;

namespace WaybillServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaybillController : Controller
    {
        private readonly TritoExpressContext _context;


        public WaybillController(TritoExpressContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get-waybills")]
        public IActionResult GetWaybills()
        {
            List<Waybill> waybills = _context.Waybills.ToList();
            return (Ok(waybills));
        }


        [HttpGet]
        [Route("get-waybill/{Id}")]
        public IActionResult GetWaybill(int Id)
        {
            Waybill waybill = _context.Waybills.Where(p => p.WaybillId == Id).FirstOrDefault();
            return (Ok(waybill));
        }


     
        [HttpPost]
        [Route("create-waybill")]
        public IActionResult Create(Waybill waybill)
        {
            _context.Attach(waybill);
            _context.Entry(waybill).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();

            return (Ok(true));

        }
    }
}
