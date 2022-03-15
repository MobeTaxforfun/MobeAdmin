using Microsoft.AspNetCore.Mvc;
using MobeAdmin.Service.Interface;
using MobeAdmin.Service.ViewModel.ProductManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobeAdmin.Areas.ProductManage.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        public async Task<IActionResult> Index()
        {
            var ListedProducts = await _ProductService.ListedProductAsync();
            return View();
        }

        public async Task<IActionResult> Create(CreateProductViewModel Model)
        {
            CreateProductViewModel TestMode = new CreateProductViewModel
            {
                ProductCount = 10,
                ProductName = "TEST",
                CreateTime = DateTime.Now,
                UnitPrice = 1
            };
            await _ProductService.CreateProductAsync(TestMode);
            return View();
        }

        public async Task<IActionResult> Update(UpdateProductViewModel Model)
        {
            await _ProductService.UpdateProductAsync(Model);
            return View();
        }

        public async Task<IActionResult> Delete(DeleteProductViewMode Model)
        {
            await _ProductService.DeleteProductAsync(Model);
            return View();
        }
    }
}
