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
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly CustomerContext _context;

        public ProductController(ILogger<ProductController> logger, CustomerContext context)
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
            var p = _context.Products;
            
            // var put = _context.Products.First(e => e.id == 2);
            // put.name = "orange";
            // _context.SaveChanges();
            // return Ok(put);
            return Ok(new {message = "success retrieve data", status = true, data = p});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pro = _context.Products.First( e => e.id == id);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = pro});
        }

        [HttpPost]
        public IActionResult Post(DateTime created_at, DateTime updated_at)
        {
            var res = new Product
            {
                name = "apple", 
                price = 100000, 
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            _context.Products.Add(res);
            _context.SaveChanges();
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var del = _context.Products.First( e => e.id == id);
            _context.Products.Remove(del);
            _context.SaveChanges();
            return Ok("deleted");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var put = _context.Products.Find(id);
            put.name = "orange";
            put.created_at = DateTime.Now;
            put.updated_at = DateTime.Now;
            _context.SaveChanges();
            return Ok(new {status = "accepted", data = put});
        }
    }
}
