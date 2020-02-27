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
    [Route("api/OrderItems")]
    public class OrderItemsController : ControllerBase
    {
        private readonly ILogger<OrderItemsController> _logger;
        private readonly CustomerContext _context;

        public OrderItemsController(ILogger<OrderItemsController> logger, CustomerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // var o = new OrderItems
            // {
            //     order_id = 1,
            //     product_id = 1,
            //     quantity = 1
            // };
            // _context.OrderItems.Add(o);
            // _context.SaveChanges();
            var ori = _context.OrderItems;
            
            return Ok(new {message = "success retrieve data", status = true, data = ori});
            // var put = _context.OrderItems.First(e => e.id == 1);
            // put.order_id = 3;
            // _context.SaveChanges();
            // return Ok(put);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ors = _context.OrderItems.First( e => e.id == id);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = ors});
        }

        [HttpPost]
        public IActionResult Post(OrderItems orderItems)
        {
            // var tu = new OrderItems
            // {
            //     order_id = 3,
            //     product_id = 2,
            //     quantity = 4

            // };

            _context.OrderItems.Add(orderItems);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = orderItems});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var del = _context.OrderItems.First( e => e.id == id);
            _context.OrderItems.Remove(del);
            _context.SaveChanges();
            return Ok("deleted");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var put = _context.OrderItems.Find(id);
            put.quantity = 5;
            _context.SaveChanges();
            return Ok(new {status = "accepted", data = put});
        }
        
    }
}
