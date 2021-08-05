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
        public List<ProductCountOfBrand> GetAllProductCountOfBrand()
        {
            using(SqlServerContext context=new SqlServerContext())
            {
                var result = from p in context.Products                           
                             join b in context.Brands
                             on p.BrandId equals b.ID
                             group p by b.Name into g 
                             select new ProductCountOfBrand
                             {
                                Name=g.Key,
                                ProductCount=g.Count()
                             };
                return result.ToList();
            }
        }
    }
}
