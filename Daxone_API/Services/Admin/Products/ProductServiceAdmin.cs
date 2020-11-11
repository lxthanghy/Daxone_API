using Daxone_API.Models;
using Daxone_API.ViewModels.Admin.Common;
using Daxone_API.ViewModels.Admin.Product;
using Daxone_API.ViewModels.Admin.ProductCategory;
using Daxone_API.ViewModels.Admin.Supplier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Admin.Products
{
    public class ProductServiceAdmin : IProductServiceAdmin
    {
        private readonly DaxoneDBContext _daxoneDBContext;

        public ProductServiceAdmin(DaxoneDBContext daxoneDBContext)
        {
            _daxoneDBContext = daxoneDBContext;
        }

        public async Task<int> Add(AddProductViewModel addProductViewModel)
        {
            try
            {
                Product product = new Product()
                {
                    Name = addProductViewModel.Name,
                    ImageUrl = addProductViewModel.ImageUrl,
                    Description = addProductViewModel.Description,
                    Price = addProductViewModel.Price,
                    Quantity = addProductViewModel.Quantity,
                    CategoryId = addProductViewModel.CategoryId,
                    SupplierId = addProductViewModel.SupplierId,
                    PromotionPrice = addProductViewModel.PromotionPrice,
                    Warranty = addProductViewModel.Warranty,
                    Frame = addProductViewModel.Frame,
                    Rims = addProductViewModel.Rims,
                    Tires = addProductViewModel.Tires,
                    Weight = addProductViewModel.Weight,
                    WeightLimit = addProductViewModel.WeightLimit,
                    Status = addProductViewModel.Status,
                    ShowOnHome = addProductViewModel.ShowOnHome
                };
                _daxoneDBContext.Products.Add(product);
                int res = await _daxoneDBContext.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public IQueryable<ProductCategorySelectViewModel> getDataSelectProductCategory()
        {
            try
            {
                var data = from pc in _daxoneDBContext.ProductCategories
                           select new ProductCategorySelectViewModel()
                           {
                               Id = pc.Id,
                               Name = pc.Name
                           };
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IQueryable<SupplierSelectViewModel> getDataSelectSupplier()
        {
            try
            {
                var data = from s in _daxoneDBContext.Suppliers
                           select new SupplierSelectViewModel()
                           {
                               Id = s.Id,
                               Name = s.Name
                           };
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PaginationViewModel> Pagination(Dictionary<string, object> data)
        {
            PaginationViewModel paginationViewModel = new PaginationViewModel();
            try
            {
                int page = int.Parse(data["page"].ToString());
                int pageSize = int.Parse(data["pageSize"].ToString());
                string nameSearch = "";
                if (data.ContainsKey("nameSearch") && !string.IsNullOrEmpty(data["nameSearch"].ToString().Trim()))
                    nameSearch = data["nameSearch"].ToString().Trim().ToLower();
                paginationViewModel.Page = page;
                paginationViewModel.PageSize = pageSize;
                paginationViewModel.TotalItems = await _daxoneDBContext.Products.Where(x => x.Name.ToLower().IndexOf(nameSearch) >= 0).CountAsync();
                var model = from pro in _daxoneDBContext.Products
                            select new ProductViewModel
                            {
                                Id = pro.Id,
                                Name = pro.Name,
                                ImageUrl = pro.ImageUrl,
                                Price = pro.Price,
                                Quantity = pro.Quantity,
                                Status = pro.Status,
                                ShowOnHome = pro.ShowOnHome,
                                CreatedDate = pro.CreatedDate
                            };
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Name);
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Name);
                        break;
                }
                string sortByCreatedDate = "";
                if (data.ContainsKey("sortByCreatedDate") && !string.IsNullOrEmpty(data["sortByCreatedDate"].ToString().Trim()))
                    sortByCreatedDate = data["sortByCreatedDate"].ToString().Trim().ToLower();
                switch (sortByCreatedDate)
                {
                    case "asc":
                        model = model.OrderBy(x => x.CreatedDate);
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.CreatedDate);
                        break;
                }
                string sortByPrice = "";
                if (data.ContainsKey("sortByPrice") && !string.IsNullOrEmpty(data["sortByPrice"].ToString().Trim()))
                    sortByPrice = data["sortByPrice"].ToString().Trim().ToLower();
                switch (sortByPrice)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Price);
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Price);
                        break;
                }
                paginationViewModel.Data = model.Where(x => x.Name.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paginationViewModel;
        }
    }
}