using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IBaseRepository<T,V> where T : class,new() where V : class,new()
    {
        IQueryable<V> GetAll();
        V GetById(int id) ;
        int Insert(T entity) ;
        int Update(T entity) ;
        int Delete(int id) ;
        int GetPKValue(Object entity);
    }
}
