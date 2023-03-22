using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint
    //class : ref type
    //IEntity : Must be IEntity or implements IEntity
    public interface IEntityIRepository<T> where T : class,IEntity
    { 
        //makes linq filter predicate
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //never need that 
        /*List<T> GetAllByCategory(int categoryId);*/
    }
}
