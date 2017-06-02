using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductCachingRepository : LINQProductRepository
    {
        public override List<Product> GetList()
        {
            base.GetList();
            List<Product> products = (List<Product>)HttpRuntime.Cache["ProductList"];
            if (products == null)
            {
                products = base.GetList();
                HttpRuntime.Cache["ProductList"] = products;
            }
            return products;
    }

    
    public override void Save(Product product)
        {
            base.Save(product);
            HttpRuntime.Cache["ProductList"] = null;
        }
        public override Product Get(int id)
        {
            HttpRuntime.Cache["ProductList"] = null;
            return (base.Get(id));            
        }
    }
}