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
        private readonly IProductRepostory _ProductRepostory;
        public ProductService(IProductRepostory ProductRepostory)
        {
            _ProductRepostory = ProductRepostory;
        }

        public async Task<List<ProductViewModel>> ListedProductAsync()
        {
            var result = await _ProductRepostory.ListedAllAsync();
            result.ToList();
            return new List<ProductViewModel>();
        }

        public async Task<bool> CreateProductAsync(CreateProductViewModel model)
        {
            return await _ProductRepostory.CreateAsync(model);
        }

        public async Task<bool> DeleteProductAsync(DeleteProductViewMode model)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductAsync(UpdateProductViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
