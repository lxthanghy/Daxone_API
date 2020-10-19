using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daxone_API.Services.Client.ProductCategories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Daxone_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = pro
        }

        // GET: api/<ProductCategoriesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductCategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductCategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductCategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductCategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}