using AutoMapper;
using CategoryServiceSE1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Helpers
{
    public class Helper : Profile
    {
        public Helper()
        {
            CreateMap<CategoryInfo, CategoryModel>().ForMember(c => c.Product, opt => opt.Ignore());
            CreateMap<ProductInfo, ProductModel>();
            CreateMap<CategoryModel, CategoryInfo>().ForMember(c => c.Products, opt => opt.Ignore());
            CreateMap<ProductModel, ProductInfo>();
        }
    }
}
