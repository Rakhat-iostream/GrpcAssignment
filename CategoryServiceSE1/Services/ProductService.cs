using AutoMapper;
using CategoryServiceSE1.Models;
using CategoryServiceSE1.Repositories.Interfaces;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Services
{
    public class ProductService : Shop.ShopBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository, IMapper mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public override async Task<ProductInfo> AddProduct(ProductCreate request, ServerCallContext context)
        {
            var product = _mapper.Map<ProductModel>(request);
            return _mapper.Map<ProductInfo>(await _productRepository.AddProduct(product));
        }

        public override async Task<ProductInfo> GetProductById(ProductLookup request, ServerCallContext context)
        {
            return _mapper.Map<ProductInfo>(await _productRepository.GetProductById(int.Parse(request.Id)));
        }

        public override async Task<ProductInfo> UpdateProduct(ProductCreate request, ServerCallContext context)
        {
            var product = await _productRepository.GetProductById(request.CategoryId);
            return _mapper.Map<ProductInfo>(await _productRepository.UpdateProduct(product));
        }

        public override async Task<ProductInfo> DeleteProduct(ProductLookup request, ServerCallContext context)
        {
            var product = await _productRepository.GetProductById(int.Parse(request.Id));
            return _mapper.Map<ProductInfo>(await _productRepository.DeleteProduct(product));
        }


    }
}
