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
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly CustomerContext _context;

        public OrderController(ILogger<OrderController> logger, CustomerContext context)
        {
            _logger = logger;
            _context = context;
        }
    
        [HttpGet]
        public IActionResult Get()
        {
            // var p = new Product
            // {
            //     name = "apple",
            //     price = 10000
            // };
            // _context.Products.Add(p);
            // _context.SaveChanges();
            var p = _context.Orders;
            
            // var put = _context.Products.First(e => e.id == 2);
            // put.name = "orange";
            // _context.SaveChanges();
            // return Ok(put);
            return Ok(new {message = "success retrieve data", status = true, data = p});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var o = _context.Orders.First( e => e.id == id);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = o});
        }

        [HttpPost]
        public IActionResult Post(DateTime created_at, DateTime updated_at)
        {
            var res = new Order
            {
                user_id = 1,
                driver_id = 2,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            _context.Orders.Add(res);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = res});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var del = _context.Orders.First( e => e.id == id);
            _context.Orders.Remove(del);
            _context.SaveChanges();
            return Ok("deleted");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var put = _context.Orders.First(e => e.id == id);
            put.driver_id = 4;
            _context.SaveChanges();
            return Ok(new {status = "accepted", data = put});
        }
    }
}

