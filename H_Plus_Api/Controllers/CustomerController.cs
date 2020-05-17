using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H_Plus_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H_Plus_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly H_Plus_SportsContext _context;

        public CustomerController(H_Plus_SportsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return new ObjectResult(_context.Customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await _context.Customer.SingleOrDefault(m => m.CustomerId = id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getCustomer", new {id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer([FromRoute] int id, [FromBody] object obj)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            return Ok();
        }
    }
}