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
        Task<int> CreateProductAsync(CreateProductViewModel model);
        Task<int> UpdateProductAsync(UpdateProductViewModel model);
        Task<int> DeleteProductAsync(DeleteProductViewMode model);
        Task<Product> GetProductByIdAsync(int id);
    }
}
