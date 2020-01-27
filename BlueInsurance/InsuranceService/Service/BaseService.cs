using DAL.Context;
using DAL.IRepository;
using DAL.Models;
using DAL.Repository;
using InsuranceService.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceService.Service
{
    public class BaseService<T,V> : IBaseService<T,V> 
         where T : class, new()
        where V : class, new()
    {
        protected IBaseRepository<T,V> _baseRepsitory;
        protected InsuranceContext _context;
        public BaseService()
        {
            _baseRepsitory = new BaseRepository<T,V>();
            _context = new InsuranceContext();
        }
        public int Delete(int id)
        {
            int success = -1;
            try
            {
                success = _baseRepsitory.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

        public virtual List<V> GetAll()
        {
            List<V> recordToReturn = null;
            try
            {
                recordToReturn = _baseRepsitory.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return recordToReturn;
        }

        public V GetById(int id)
        {
            V recordToReturn = null;
            try
            {
                recordToReturn = _baseRepsitory.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return recordToReturn;
        }

        public virtual int CreateorUpdate(T entity)
        {
            int success = -1;
            try
            {
                int pkValue = _baseRepsitory.GetPKValue(entity);
                if (pkValue == 0)
                {
                    success = _baseRepsitory.Insert(entity);
                }
                else
                {
                    success = _baseRepsitory.Update(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

      



    }
}
