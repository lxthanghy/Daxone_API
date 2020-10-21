using Daxone_API.Models;
using Daxone_API.ViewModels.Client.Product;
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

        public async Task<ProductDetailViewModel> GetById(long id)
        {
            var res = await _daxoneDBContext.Products.Include(x => x.Category).Include(x => x.Supplier).FirstOrDefaultAsync(p => p.Id == id);
            return new ProductDetailViewModel()
            {
                Id = res.Id,
                Name = res.Name,
                MetaTitle = res.MetaTitle,
                Description = res.Description,
                ImageUrl = res.ImageUrl,
                MoreImage = res.MoreImage,
                Price = res.Price,
                CategoryName = res.Category.Name,
                SupplierName = res.Supplier.Name,
                TotalReview = res.TotalReview,
                TotalRating = res.TotalRating,
                PromotionPrice = res.PromotionPrice,
                Warranty = res.Warranty,
                Frame = res.Frame,
                Rims = res.Rims,
                Tires = res.Tires,
                Weight = res.Weight,
                WeightLimit = res.WeightLimit,
                ViewCount = res.ViewCount
            };
        }

        public async Task<List<ProductHomeViewModel>> GetProductHome()
        {
            return await _daxoneDBContext.Products.Select(p => new ProductHomeViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                MetaTitle = p.MetaTitle,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                PromotionPrice = p.PromotionPrice,
                SupplierName = p.Supplier.Name
            }).ToListAsync();
        }
    }
}