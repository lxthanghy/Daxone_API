using Daxone_API.Models;
using Daxone_API.ViewModels.Client.Order;
using Daxone_API.ViewModels.Client.OrderDetail;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.Orders
{
    public class OrderService : IOrderService
    {
        private readonly DaxoneDBContext _daxoneDBContext;

        public OrderService(DaxoneDBContext daxoneDBContext)
        {
            _daxoneDBContext = daxoneDBContext;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _daxoneDBContext.Orders.ToListAsync();
        }

        public async Task<int> Add(AddOrderViewModel orderViewModel)
        {
            Order order = new Order()
            {
                OrderName = orderViewModel.OrderName,
                OrderAddress = orderViewModel.OrderAddress,
                OrderEmail = orderViewModel.OrderEmail,
                OrderPhone = orderViewModel.OrderPhone,
                OrderNote = orderViewModel.OrderNote,
                TotalMoney = orderViewModel.TotalMoney,
                PaymentStatus = 0
            };
            _daxoneDBContext.Orders.Add(order);
            var res = await _daxoneDBContext.SaveChangesAsync();
            var ods = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(orderViewModel.OrderDetails);
            foreach (var p in ods)
            {
                OrderDetail od = new OrderDetail()
                {
                    ProductId = p.Id,
                    OrderId = order.Id,
                    Price = p.Price,
                    Quantity = p.Quantity
                };
                _daxoneDBContext.OrderDetails.Add(od);
                await _daxoneDBContext.SaveChangesAsync();
            }
            return res;
        }
    }
}