using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductCountOfBrand:IDto
    {
        public string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
