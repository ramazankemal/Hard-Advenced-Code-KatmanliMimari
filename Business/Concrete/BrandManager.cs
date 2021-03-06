using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<ProductCountOfBrandDto>> GetAllProductCountOfBrand()
        {
            return new SuccessDataResult<List<ProductCountOfBrandDto>>(_brandDal.GetAllProductCountOfBrand());
        }
    }
}
