using MobeAdmin.DataAccess.Interface;
using MobeAdmin.Domain.Model;
using MobeAdmin.Service.Interface;
using MobeAdmin.Service.ViewModel.ProductManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Service.Service
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepostory ProductRepostory)
        {

        }

        public async Task<List<ProductViewModel>> ListedProductAsync()
        {
            return null;
        }

        public Task<bool> CreateProductAsync(CreateProductViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(CreateProductViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(CreateProductViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
