using Daxone_API.ViewModels.Admin.Common;
using Daxone_API.ViewModels.Admin.Product;
using Daxone_API.ViewModels.Admin.ProductCategory;
using Daxone_API.ViewModels.Admin.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Admin.Products
{
    public interface IProductServiceAdmin
    {
        Task<PaginationViewModel> Pagination(Dictionary<string, object> data);

        Task<int> Add(AddProductViewModel addProductViewModel);

        IQueryable<SupplierSelectViewModel> getDataSelectSupplier();

        IQueryable<ProductCategorySelectViewModel> getDataSelectProductCategory();
    }
}