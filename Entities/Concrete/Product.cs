using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string WebId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short UnitsInStock { get; set; }     
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
