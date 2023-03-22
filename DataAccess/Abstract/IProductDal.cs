using Core.DataAccess;
using Entities.DTOs;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityIRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
