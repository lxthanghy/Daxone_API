using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daxone_API.Models;
using Daxone_API.Services.Client.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace Daxone_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/<SuppliersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _supplierService.GetAll();
            return Ok(data);
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}