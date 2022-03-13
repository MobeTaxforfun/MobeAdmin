using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Domain.Model
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductCount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
