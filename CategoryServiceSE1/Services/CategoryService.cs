using CategoryServiceSE1.Repositories.Interfaces;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Services
{
    public class CategoryService : Shop.ShopBase
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ILogger<CategoryService> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public override async Task<CategoryInfo> AddCategory(CategoryCreate request, ServerCallContext context)
        {
            var res = await _categoryRepository.AddCategory(request);
            var categoryInfo = new CategoryInfo()
            {
                Id = res.Id,
                Name = res.Name,
                ParentCategoryId = res.ParentCategoryId
            };

            return categoryInfo;
        }

        public override Task<CategoryInfo> GetCategoryById(CategoryLookup request, ServerCallContext context)
        {
            return base.GetCategoryById(request, context);
        }

        public override Task<ProductInfo> AddProduct(ProductCreate request, ServerCallContext context)
        {
            return base.AddProduct(request, context);
        }

        public override Task<ProductInfo> GetProductById(ProductLookup request, ServerCallContext context)
        {
            return base.GetProductById(request, context);
        }

        public override Task GetProductsByCategoryId(CategoryLookup request, IServerStreamWriter<ProductInfo> responseStream, ServerCallContext context)
        {
            return base.GetProductsByCategoryId(request, responseStream, context);
        }

    }
}
