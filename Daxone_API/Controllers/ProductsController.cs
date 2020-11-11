using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Daxone_API.Services.Admin.Products;
using Daxone_API.Services.Client.Products;
using Daxone_API.ViewModels.Admin.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Daxone_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductServiceAdmin _productServiceAdmin;
        private string _path;

        public ProductsController(IProductService productService, IProductServiceAdmin productServiceAdmin, IConfiguration configuration)
        {
            _productService = productService;
            _productServiceAdmin = productServiceAdmin;
            _path = configuration["AppSettings:PATH"];
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _productService.GetProductHome();
            return Ok(data);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination([FromBody] Dictionary<string, object> data)
        {
            var model = await _productServiceAdmin.Pagination(data);
            return Ok(model);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> Detail(long id)
        {
            var product = await _productServiceAdmin.Detail(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("{id}/edit")]
        public async Task<IActionResult> Edit(long id)
        {
            var product = await _productServiceAdmin.Edit(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("data-select-supplier")]
        public IActionResult GetDataSelectSupplier()
        {
            var data = _productServiceAdmin.getDataSelectSupplier();
            return Ok(data);
        }

        [HttpGet("data-select-product-category")]
        public IActionResult GetDataSelectProductCategory()
        {
            var data = _productServiceAdmin.getDataSelectProductCategory();
            return Ok(data);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductViewModel addProductViewModel)
        {
            if (addProductViewModel.ImageUrl != null)
            {
                var arrData = addProductViewModel.ImageUrl.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $"{arrData[0]}";
                    addProductViewModel.ImageUrl = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            var res = await _productServiceAdmin.Add(addProductViewModel);
            if (res == 0) return BadRequest();
            return Ok(res);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductViewModel updateProductViewModel)
        {
            if (updateProductViewModel.ImageUrl != null)
            {
                var arrData = updateProductViewModel.ImageUrl.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $"{arrData[0]}";
                    updateProductViewModel.ImageUrl = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            var res = await _productServiceAdmin.Update(id, updateProductViewModel);
            if (res == -1) return BadRequest();
            return Ok(res);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _productServiceAdmin.Delete(id);
            if (res == -1) return BadRequest();
            return Ok(res);
        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }

        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}