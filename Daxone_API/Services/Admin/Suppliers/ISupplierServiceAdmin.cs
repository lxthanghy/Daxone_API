using Daxone_API.Models;
using Daxone_API.ViewModels.Admin.Common;
using Daxone_API.ViewModels.Admin.Supplier;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Admin.Suppliers
{
    public interface ISupplierServiceAdmin
    {
        Task<PaginationViewModel> Pagination(Dictionary<string, object> data);

        Task<int> Add(AddSupplierViewModel addSupplierViewModel);

        Task<Supplier> Get(long id);

        Task<int> Update(long id, Supplier supplier);

        Task<int> Delete(long id);
    }
}