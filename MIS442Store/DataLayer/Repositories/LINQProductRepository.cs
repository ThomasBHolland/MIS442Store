using MIS442Store.DataLayer;
using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class LINQProductRepository : IProductRepository
    {
        private MIS442DBDataContext _DataContext = new MIS442DBDataContext();

        public Product Get(int id)
        {
            Product product = null;
            ProductDO productDO = _DataContext.spProduct_Get(id).SingleOrDefault();
            if (productDO != null)
            {
                product.ProductID = productDO.ProductID;
                product.ProductCode = productDO.ProductCode;
                product.ProductName = productDO.ProductName;
                product.ProductVersion = productDO.ProductVersion;
                product.ProductReleaseDate = productDO.ProductReleaseDate;


            }
            return product;

        }

        public List<Product> GetList()
        {
            List<Product> productList = new List<Product>();
            ISingleResult<ProductDO> productDOs = _DataContext.spProduct_GetList();
            foreach (var p in productDOs)
            {
                Product product = new Product();
                product.ProductID = p.ProductID;
                product.ProductCode = p.ProductCode;
                product.ProductName = p.ProductName;
                product.ProductVersion = p.ProductVersion;
                product.ProductReleaseDate = p.ProductReleaseDate;
                
                productList.Add(product);
            }
            return productList;
        }

        public void Save(Product product)
        {
            if (product.ProductID == 0)
            {
                _DataContext.spProduct_InsertUpdate(null, product.ProductCode, product.ProductName, product.ProductVersion,product.ProductReleaseDate);
            }
            else
            {
                _DataContext.spProduct_InsertUpdate(product.ProductID, product.ProductCode, product.ProductName, product.ProductVersion, product.ProductReleaseDate);
            }

        }
    }





}