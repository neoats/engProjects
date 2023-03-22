using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
        /*    _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="glass",UnitPrice=15,UnitInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="pencil",UnitPrice=200,UnitInStock=33},
                new Product{ProductId=3,CategoryId=2,ProductName="eraser",UnitPrice=150,UnitInStock=15},
                new Product{ProductId=4,CategoryId=2,ProductName="notebook",UnitPrice=112,UnitInStock=22},
                new Product{ProductId=5,CategoryId=3,ProductName="book",UnitPrice=15,UnitInStock=1},
            };*/
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*   Product productToDelete = null;
               foreach (var p in _products)
               {
                   if (product.ProductId== p.ProductId)
                   {
                       productToDelete = p;
                   }
               }*/
            Product productToDelete = _products.SingleOrDefault(p =>  product.ProductId == p.ProductId);
            _products.Remove(productToDelete);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

   

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId) => _products.Where(p=>p.CategoryId== categoryId).ToList();
   

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => product.ProductId == p.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId= product.CategoryId;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.UnitsInStock= product.UnitsInStock;
        }
    }
}
