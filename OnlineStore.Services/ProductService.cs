﻿using OnlineStore.Entities;
using OnlineStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Products
{
    public class ProductService
    {
        public List<Product> GetOldProducts()
        {
            GetProductsFromDB productsFromDB = new GetProductsFromDB(); 

            return productsFromDB.GetProducts().ToList().Where(p => p.Id <= 2).ToList();
        }
    }
}