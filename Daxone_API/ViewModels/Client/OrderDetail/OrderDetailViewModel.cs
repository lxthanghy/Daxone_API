using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.ViewModels.Client.OrderDetail
{
    public class OrderDetailViewModel
    {
        public long Id { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}