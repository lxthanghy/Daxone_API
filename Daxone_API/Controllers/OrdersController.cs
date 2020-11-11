using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daxone_API.Models;
using Daxone_API.Services.Client.OrderDetails;
using Daxone_API.Services.Client.Orders;
using Daxone_API.ViewModels.Client.Order;
using Microsoft.AspNetCore.Mvc;

namespace Daxone_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _orderService.GetAll();
            return Ok(data);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderViewModel orderViewModel)
        {
            var res = await _orderService.Add(orderViewModel);
            if (res == 0) return BadRequest();
            return Ok(res);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}