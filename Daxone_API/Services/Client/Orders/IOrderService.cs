using Daxone_API.Models;
using Daxone_API.ViewModels.Client.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.Orders
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();

        Task<int> Add(AddOrderViewModel orderViewModel);
    }
}