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
        public List<ProductDetailDto> GetProductDetails()
        {
            using (SqlServerContext contex=new SqlServerContext())
            {
                var result = from p in contex.Product
                             join c in contex.Category
                             on p.CategoryId equals c.ID
                             select new ProductDetailDto 
                             {
                                 ID=p.ID,
                                 Name=p.Name,
                                 CategoryName=c.Name,
                                 UnitsInStock=p.UnitsInStock 
                             };
                return result.ToList();
            } 
        }
    }
}
