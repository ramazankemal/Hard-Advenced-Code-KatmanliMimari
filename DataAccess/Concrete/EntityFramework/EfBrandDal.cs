using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, SqlServerContext>, IBrandDal
    {
        public List<ProductCountOfBrandDto> GetAllProductCountOfBrand()
        {
            using(SqlServerContext context=new SqlServerContext())
            {

                var result = from p in context.Products
                              join b in context.Brands
                              on p.BrandId equals b.ID
                              group new { p, b } by new { b.Name, b.ID } into g
                              select new ProductCountOfBrandDto
                              {
                                  BrandId = g.Key.ID,
                                  Name = g.Key.Name,
                                  ProductCount = g.Count()
                              };
                return result.ToList();

            }
        }
    }
}
