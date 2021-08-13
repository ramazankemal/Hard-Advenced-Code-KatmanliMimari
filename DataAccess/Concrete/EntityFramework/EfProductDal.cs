using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, SqlServerContext>, IProductDal
    {
        public ProductDetailDto GetProductDetails(int id)
        {
            using (SqlServerContext contex=new SqlServerContext())
            {

                var result = from p in contex.Products
                             join c in contex.Categories
                             on p.CategoryId equals c.ID
                             join b in contex.Brands
                             on p.BrandId equals b.ID
                             where p.ID == id
                             select new ProductDetailDto
                             {
                                 ID = p.ID,
                                 Name = p.Name,
                                 CateogryId = c.ID,
                                 CategoryName = c.Name,
                                 BrandId = b.ID,
                                 BrandName = b.Name,
                                 WebId = p.WebId,
                                 Description = p.Description,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitPrice = p.UnitPrice,
                                 ImagePath = p.ImagePath,
                                 Recommended = p.Recommended,
                                 Images = (from i in contex.ProductImages
                                          where i.ProductId == id
                                          select new ProductImage
                                          {
                                              ID=i.ID,
                                              ProductId=i.ProductId,
                                              ImagePath=i.ImagePath
                                          }).ToList()
                               
                             };
                return result.FirstOrDefault();
            } 
        }
    }
}
