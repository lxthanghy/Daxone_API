using Daxone_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.Products
{
    public class ProductService : IProductService
    {
        private readonly DaxoneDBContext _daxoneDBContext;

        public ProductService(DaxoneDBContext daxoneDBContext)
        {
            _daxoneDBContext = daxoneDBContext;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _daxoneDBContext.Products.ToListAsync();
        }
    }
}