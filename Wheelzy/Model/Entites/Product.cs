using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelzy.Model.Entites
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        [Required]
        [StringLength(50)]
        public string SubCategory { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
