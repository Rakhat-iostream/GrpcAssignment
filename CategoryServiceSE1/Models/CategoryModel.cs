﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /*public int ParentCategoryId { get; set; }*/
        public List<ProductModel> Product{ get; set; }  
    }
}
