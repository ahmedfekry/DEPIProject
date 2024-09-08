using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure
{
    public class GetProductsFromDB
    {
        public List<Product> GetProducts()
        {
            return new List<Product> { new Product() { Id=1,Name="Product1"},
                                       new Product() { Id=2,Name="Product2"},
                                       new Product() { Id=3,Name="Product3"}};
        }
    }
}
