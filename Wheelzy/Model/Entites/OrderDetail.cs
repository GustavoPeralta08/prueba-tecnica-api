using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelzy.Model.Entites
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Required]
        public int CantxProdut { get; set; }

        [ForeignKey("OrderId")]
        Order Order { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        Product Product { get; set; }

        public int ProductId { get; set; }


    }
}
