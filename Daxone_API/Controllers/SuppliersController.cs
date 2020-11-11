using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Daxone_API.Models;
using Daxone_API.Services.Admin.Suppliers;
using Daxone_API.Services.Client.Suppliers;
using Daxone_API.ViewModels.Admin.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace Daxone_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly ISupplierServiceAdmin _supplierServiceAdmin;

        public SuppliersController(ISupplierService supplierService, ISupplierServiceAdmin supplierServiceAdmin)
        {
            _supplierService = supplierService;
            _supplierServiceAdmin = supplierServiceAdmin;
        }

        // GET: api/<SuppliersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _supplierService.GetAll();
            return Ok(data);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination([FromBody] Dictionary<string, object> data)
        {
            var model = await _supplierServiceAdmin.Pagination(data);
            return Ok(model);
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var supplier = await _supplierServiceAdmin.Get(id);
            if (supplier == null) return BadRequest();
            return Ok(supplier);
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] AddSupplierViewModel addSupplierViewModel)
        {
            var res = await _supplierServiceAdmin.Add(addSupplierViewModel);
            if (res == 0) return BadRequest();
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Supplier supplier)
        {
            var res = await _supplierServiceAdmin.Update(id, supplier);
            if (res == -1) return BadRequest();
            return Ok(res);
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _supplierServiceAdmin.Delete(id);
            if (res == -1) return BadRequest();
            return Ok(res);
        }
    }
}