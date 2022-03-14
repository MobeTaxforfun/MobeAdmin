using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Service.ViewModel.ProductManage
{
    public class ProductViewModel
    {
    }

    public class ListedViewModel
    {
        public string ProductName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductCount { get; set; }
        public decimal UnitPrice { get; set; }
    }
    public class CreateProductViewModel
    {
        public string ProductName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductCount { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductCount { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class DeleteProductViewMode
    {
        public int Id { get; set; }
    }
}
