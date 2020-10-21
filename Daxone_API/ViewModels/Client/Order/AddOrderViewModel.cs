using Daxone_API.ViewModels.Client.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.ViewModels.Client.Order
{
    public class AddOrderViewModel
    {
        public long? UserId { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderEmail { get; set; }
        public string OrderPhone { get; set; }
        public string OrderNote { get; set; }
        public decimal? TotalMoney { get; set; }
        public string OrderDetails { get; set; }
    }
}