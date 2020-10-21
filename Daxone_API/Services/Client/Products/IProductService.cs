using Daxone_API.Models;
using Daxone_API.ViewModels.Client.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.Products
{
    public interface IProductService
    {
        Task<List<ProductHomeViewModel>> GetProductHome();

        Task<ProductDetailViewModel> GetById(long id);
    }
}