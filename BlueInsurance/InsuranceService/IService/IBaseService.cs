using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceService.IService
{
    public interface IBaseService<T,V> where T:class where V : class
    {
        List<V> GetAll();
        V GetById(int id);
        int CreateorUpdate(T entity);
        
        int Delete(int id);
    }
}
