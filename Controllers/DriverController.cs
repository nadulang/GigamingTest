using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using nadya_asp_rest_test1.Models;


namespace nadya_asp_rest_test1.Controllers
{
    [ApiController]
    [Route("api/Driver")]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        private readonly CustomerContext _context;

        public DriverController(ILogger<DriverController> logger, CustomerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // var d = new Driver
            // {
            //     full_name = "johny",
            //     phone_number = "0812345689"
            // };
            // _context.Drivers.Add(d);
            // _context.SaveChanges();
            var d = _context.Drivers;
            // var put = _context.Drivers.First(e => e.id == 3);
            // put.full_name = "donny";
            // _context.SaveChanges();
            // return Ok(new {message = "success retrieve data", status = true, data = put});
            return Ok(new {message = "success retrieve data", status = true, data = d});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var drive = _context.Drivers.First( e => e.id == id);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = drive});
        }

        [HttpPost]
        public IActionResult Post(Driver drivers)
        {
            // var dro = new Driver
            // {
            //     full_name = "donna", 
            //     phone_number = "0812765676",
            //     created_at = DateTime.Now,
            //     updated_at = DateTime.Now
            // };

            _context.Drivers.Add(drivers);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data =drivers});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var del = _context.Drivers.First( e => e.id == id);
            _context.Drivers.Remove(del);
            _context.SaveChanges();
            return Ok("deleted");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var put = _context.Drivers.Find(id);
            put.full_name = "Jane";
            put.created_at = DateTime.Now;
            put.updated_at= DateTime.Now;
            _context.SaveChanges();
            return Ok(new {status = "accepted", data = put});
        }
    }
}
