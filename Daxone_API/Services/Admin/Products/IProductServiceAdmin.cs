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

        Task<DetailProductViewModel> Detail(long id);

        Task<UpdateProductViewModel> Edit(long id);

        IQueryable<SupplierSelectViewModel> getDataSelectSupplier();

        IQueryable<ProductCategorySelectViewModel> getDataSelectProductCategory();

        Task<int> Update(long id, UpdateProductViewModel updateProductViewModel);

        Task<int> Delete(long id);
    }
}