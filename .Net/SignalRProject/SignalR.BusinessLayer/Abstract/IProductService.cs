﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        public List<Product> GetProductsWithCategories();
        public int TProductCount();
        public int TProductCountByCategoryNameDrink();
        public int TProductCountByCategoryNameHamburger();

        public decimal TProductPriceAvg();
       public string TProductPriceByMaxPrice();
        public string TProductPriceByMinPrice();

        public decimal TProductPriceByHamburger();
    }
}
