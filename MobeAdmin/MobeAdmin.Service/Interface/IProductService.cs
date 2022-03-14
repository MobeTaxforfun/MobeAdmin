using MobeAdmin.Domain.Model;
using MobeAdmin.Service.ViewModel.ProductManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Service.Interface
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> ListedProductAsync();
        Task<bool> CreateProductAsync(CreateProductViewModel model);
        Task<bool> UpdateProductAsync(UpdateProductViewModel model);
        Task<bool> DeleteProductAsync(DeleteProductViewMode model);
        Task<Product> GetProductByIdAsync(int id);
    }
}
