using Daxone_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.ProductCategories
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly DaxoneDBContext _daxoneDBContext;

        public ProductCategoryService(DaxoneDBContext daxoneDBContext)
        {
            _daxoneDBContext = daxoneDBContext;
        }

        public async Task<List<ProductCategory>> GetAll()
        {
            return await _daxoneDBContext.ProductCategories.ToListAsync();
        }
    }
}