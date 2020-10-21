using Daxone_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.OrderDetails
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly DaxoneDBContext _daxoneDBContext;

        public OrderDetailService(DaxoneDBContext daxoneDBContext)
        {
            _daxoneDBContext = daxoneDBContext;
        }
    }
}