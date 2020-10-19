using Daxone_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.ProductCategories
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetAll();
    }
}