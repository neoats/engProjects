using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {//We write what we want to serve to the outside world about the category.
     /*   IDataResult<int> GetAll();*/
        IDataResult<List<Category>> GetAll( );
        IDataResult<Category> GetById(int categoryId);
    }
}
