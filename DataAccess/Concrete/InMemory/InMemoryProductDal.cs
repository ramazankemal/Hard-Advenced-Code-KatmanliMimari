using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server, Postgres, MongoDb
            _products = new List<Product> {
                new Product {ID=1,CategoryId=1,Name="Tost Makinesi",UnitPrice=150,UnitsInStock=21},
                new Product {ID=2,CategoryId=1,Name="Çay Makinesi",UnitPrice=250,UnitsInStock=23},
                new Product {ID=3,CategoryId=2,Name="Telefon",UnitPrice=1500,UnitsInStock=13},
                new Product {ID=4,CategoryId=2,Name="Tablet",UnitPrice=1900,UnitsInStock=11},
                new Product {ID=5,CategoryId=2,Name="32GB USB",UnitPrice=80,UnitsInStock=5},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p=>p.ID==product.ID);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ID == product.ID);
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
