using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelzy.Model.DTO
{
    public class OrderDto
    {
        public DateTime DateOrder { get; set; }
        public decimal TotalAmount { get; set; }
        public int CantProduct { get; set; }
    }
}
