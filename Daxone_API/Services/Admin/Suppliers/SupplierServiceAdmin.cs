using Daxone_API.Models;
using Daxone_API.ViewModels.Admin.Common;
using Daxone_API.ViewModels.Admin.Supplier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Admin.Suppliers
{
    public class SupplierServiceAdmin : ISupplierServiceAdmin
    {
        private readonly DaxoneDBContext _daxoneDBContext;

        public SupplierServiceAdmin(DaxoneDBContext daxoneDBContext)
        {
            _daxoneDBContext = daxoneDBContext;
        }

        public async Task<int> Add(AddSupplierViewModel addSupplierViewModel)
        {
            try
            {
                Supplier supplier = new Supplier()
                {
                    Name = addSupplierViewModel.Name,
                    Address = addSupplierViewModel.Address,
                    Email = addSupplierViewModel.Email,
                    Phone = addSupplierViewModel.Phone,
                    Status = addSupplierViewModel.Status
                };
                _daxoneDBContext.Suppliers.Add(supplier);
                int res = await _daxoneDBContext.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> Delete(long id)
        {
            try
            {
                Supplier supplier = await _daxoneDBContext.Suppliers.FindAsync(id);
                if (supplier == null) return -1;
                _daxoneDBContext.Suppliers.Remove(supplier);
                await _daxoneDBContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<Supplier> Get(long id)
        {
            try
            {
                Supplier supplier = await _daxoneDBContext.Suppliers.FindAsync(id);
                return supplier;
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
                paginationViewModel.TotalItems = await _daxoneDBContext.Suppliers.Where(x => x.Name.ToLower().IndexOf(nameSearch) >= 0).CountAsync();
                var model = _daxoneDBContext.Suppliers.ToList();
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Name).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Name).ToList();
                        break;
                }
                string sortByCreatedDate = "";
                if (data.ContainsKey("sortByCreatedDate") && !string.IsNullOrEmpty(data["sortByCreatedDate"].ToString().Trim()))
                    sortByCreatedDate = data["sortByCreatedDate"].ToString().Trim().ToLower();
                switch (sortByCreatedDate)
                {
                    case "asc":
                        model = model.OrderBy(x => x.CreatedDate).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.CreatedDate).ToList();
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

        public async Task<int> Update(long id, Supplier supplier)
        {
            try
            {
                Supplier supp = await _daxoneDBContext.Suppliers.FindAsync(id);
                if (supp == null) return -1;
                supp.Name = supplier.Name;
                supp.Address = supplier.Address;
                supp.Email = supplier.Email;
                supp.Phone = supplier.Phone;
                supp.Status = supplier.Status;
                await _daxoneDBContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}