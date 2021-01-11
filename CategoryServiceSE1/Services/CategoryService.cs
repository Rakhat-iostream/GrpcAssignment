using AutoMapper;
using CategoryServiceSE1.Models;
using CategoryServiceSE1.Repositories.Interfaces;
using Grpc.Core;
using Grpc.Net.Client;
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
        private readonly IMapper _mapper;
        public CategoryService(ILogger<CategoryService> logger, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public override async Task<CategoryInfo> AddCategory(CategoryCreate request, ServerCallContext context)
        {
            var model = new CategoryModel();
            model.Name = request.Name;
            /*model.ParentCategoryId = request.ParentCategoryId;*/
            var res = await _categoryRepository.AddCategory(model);
            var categoryInfo = new CategoryInfo()
            {
                Id = res.Id,
                Name = res.Name,
                /*ParentCategoryId = res.ParentCategoryId*/

            };

            return categoryInfo;
        }

        public override async Task<CategoryInfo> GetCategoryById(CategoryLookup request, ServerCallContext context)
        {
            return _mapper.Map<CategoryInfo>(await _categoryRepository.GetCategoryById(int.Parse(request.Id)));
        }

        public override async Task<CategoryInfo> UpdateCategory(CategoryCreate request, ServerCallContext context)
        {
            var category = await _categoryRepository.GetCategoryById(request.ParentCategoryId);
            if (category == null)
            {
                _logger.LogWarning("Couldn't find such category with id " + request.ParentCategoryId);
            }
            category.Name = request.Name;
            return _mapper.Map<CategoryInfo>(await _categoryRepository.UpdateCategory(category));
        }

        public override async Task<CategoryInfo> DeleteCategory(CategoryLookup request, ServerCallContext context)
        {
            var category = await _categoryRepository.GetCategoryById(int.Parse(request.Id)); 
            return _mapper.Map <CategoryInfo>(await _categoryRepository.DeleteCategory(category));
         }

        public class CategoryServiceClient
        {
            private GrpcChannel channel;

            public CategoryServiceClient(GrpcChannel channel)
            {
                this.channel = channel;
            }
        }


        /*public override async Task GetProductsByCategoryId(CategoryLookup request, IServerStreamWriter<ProductInfo> responseStream, ServerCallContext context)
        {
            _logger.LogInformation("Fetching all categories...");
            foreach (var categoryModel in await _categoryRepository.GetAll())
            {
                var category = new CategoryInfo{ Id = categoryModel.Id, Name = categoryModel.Name };
                category.Products.AddRange(categoryModel.Product.Select(p => _mapper.Map<ProductInfo>(p)));
                await responseStream.WriteAsync(category);
            }
        }*/

    }
}
