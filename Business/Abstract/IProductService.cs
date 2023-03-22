using Core.Utilities.Results;
using Entities.DTOs;
using Entity.Concrete;

namespace Business.Abstract
{

    public interface IProductService
    {
        //We write what we want to serve to the outside world about the product.
        #region oldSpunker

        /*
              List<Product> GetAll();
              List<Product> GetAllByCategoryId(int id);
              List<Product> GetByUnitPrice(decimal min,decimal max);

              List<ProductDetailDto> GetProductDetails();

              Product GetById(int productId);

              List<Product> GetAll();*/

        #endregion
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product); 
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);
        /*Func<IDataResult<List<Product>>> GetAllProductsFunc();*/
    }
}
