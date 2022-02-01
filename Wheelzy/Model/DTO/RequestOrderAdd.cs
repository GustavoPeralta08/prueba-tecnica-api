using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Model.Entites;

namespace Wheelzy.Model.DTO
{
    public class RequestOrderAdd
    {
        public string DateOrder { get; set; }
        public decimal TotalAmount { get; set; }
        public int CantProduct { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
