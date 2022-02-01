using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelzy.Model.Entites
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime DateOrder { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public int CantProduct { get; set; }
    }
}
