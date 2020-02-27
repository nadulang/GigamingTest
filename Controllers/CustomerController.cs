using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using nadya_asp_rest_test1.Models;
using Microsoft.AspNetCore.JsonPatch;


namespace nadya_asp_rest_test1.Controllers
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerContext _context;

        public CustomerController(ILogger<CustomerController> logger, CustomerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // var cust = new Customer
            // {
            //     Full_name = "johny",
            //     Username = "doe",
            //     Email = "john@doe.com",
            //     Phone_Number = "0812345689"
            // };
            // _context.Customers.Add(cust);
            // _context.SaveChanges();
            var custs = _context.Customers;
            
            return Ok(new {message = "success retrieve data", status = true, data = custs});
            // var put = _context.Customers.First(e => e.Id == 1);
            // put.Full_name = "Jane";
            // _context.SaveChanges();
            // return Ok(put);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cust = _context.Customers.First( e => e.Id == id);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = cust});
        }

        [HttpPost]
        public IActionResult Post(DateTime created_at, DateTime updated_at)
        {
            var res = new Customer
            {
                Full_name = "Jenna", 
                Username = "goe",
                Email = "jenna@ofe.com",
                Phone_Number = "098653456",
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            _context.Customers.Add(res);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = res});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var del = _context.Customers.First( e => e.Id == id);
            _context.Customers.Remove(del);
            _context.SaveChanges();
            return Ok("deleted");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var put = _context.Customers.Find(id);
            put.Full_name = "Jane";
            put.created_at = DateTime.Now;
            put.updated_at = DateTime.Now;
            _context.SaveChanges();
            return Ok(new {status = "accepted", data = put});
        }
        
    }
}
