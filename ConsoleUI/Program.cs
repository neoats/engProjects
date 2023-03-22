using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            categoryManager.GetAll().ForEach(c => Console.WriteLine(c.CategoryName));*/
          
            ProManagerDetails();
           
        }
        private static void ProManagerDetails()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName+"/"+product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

    /*    private static void ProManager(ProductManager productManager)
        {
            productManager = new ProductManager(new EfProductDal());

            productManager.GetAllByCategoryId(4).ForEach(product => Console.WriteLine(product.UnitPrice));
            Console.WriteLine(" ");

            productManager.GetByUnitPrice(40, 70).ForEach(product => Console.WriteLine(product.UnitPrice));
        }
*/

    }
}