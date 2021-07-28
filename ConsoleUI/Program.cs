using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManagerTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.Name);
            }
        }

        private static void ProductManagerTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),
                new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();

            if(result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.Name + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
