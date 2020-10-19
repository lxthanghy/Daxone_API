using Daxone_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly DaxoneDBContext _daxoneDBContext;

        public SupplierService(DaxoneDBContext daxoneDBContext)
        {
            _daxoneDBContext = daxoneDBContext;
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await _daxoneDBContext.Suppliers.ToListAsync();
        }
    }
}