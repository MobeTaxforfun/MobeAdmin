using AutoMapper;
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
        private readonly IMapper _Mapper;
        public ProductService(IMapper mapper,IProductRepostory ProductRepostory)
        {
            _ProductRepostory = ProductRepostory;
        }

        public async Task<List<ProductViewModel>> ListedProductAsync()
        {
            var result = await _ProductRepostory.ListedAllAsync();
            result.ToList();
            return new List<ProductViewModel>();
        }

        public async Task<int> CreateProductAsync(CreateProductViewModel model)
        {
            return await _ProductRepostory.CreateAsync(_Mapper.Map<Product>(model));
        }

        public async Task<int> DeleteProductAsync(DeleteProductViewMode model)
        {
            return await _ProductRepostory.DeleteAsync(model.Id);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateProductAsync(UpdateProductViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
