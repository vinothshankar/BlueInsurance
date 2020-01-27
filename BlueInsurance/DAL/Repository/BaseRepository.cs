using DAL.Context;
using DAL.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL.Repository
{
    public class BaseRepository<TEntity,VEntity> : IBaseRepository<TEntity, VEntity>
        where TEntity : class, new() where VEntity : class, new()
    {
        private InsuranceContext _tcontext;
        private readonly DbSet<TEntity> _TdbSet;
        private readonly DbSet<VEntity> _VdbSet;

        public BaseRepository()
        {
            _tcontext = new InsuranceContext();
            _TdbSet = _tcontext.Set<TEntity>();
            _VdbSet = _tcontext.Set<VEntity>();
        }
        public int Delete(int id)
        {
            int rec = 0;
            try
            {
                var dataToReturn = _TdbSet.Find(id);
                if (dataToReturn != null)
                {
                    _TdbSet.Remove(dataToReturn);
                    rec = _tcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Record not found while deleting record");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error while deleting record", ex);
            }
            return rec;
        }


        public VEntity GetById(int id)
        {
            VEntity entity = null;
            try
            {
                var dataToReturn = _VdbSet.Find(id);
                if (dataToReturn != null)
                {
                    entity = dataToReturn;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error while Fetching record", ex);
            }
            return entity;
        }

        public virtual int Insert(TEntity entity)
        {
            int rec = 0;
            try
            {
                using (var dbContextTransaction = _tcontext.Database.BeginTransaction())
                {
                    _TdbSet.Add(entity);
                    rec=_tcontext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                
            }catch(Exception ex)
            {
                throw new Exception("Error While Inserting record",ex);
            }
            return rec;
            
        }

        public int Update(TEntity entity)
        {
            int rec = 0;
            try
            {
                var pkvalue = GetPKValue(entity);
                var data = _TdbSet.Find(pkvalue);
                if (data != null)
                {
                    using (var dbContextTransaction = _tcontext.Database.BeginTransaction())
                    {
                        _tcontext.Entry(data).CurrentValues.SetValues(entity);
                        rec=_tcontext.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                }
                else
                {
                    throw new Exception("Record not found while updating");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error while updating record",ex);
            }
            return rec;
        }

        public IQueryable<VEntity> GetAll()
        {
            IQueryable<VEntity> listofItems = null;
            try
            {
                listofItems = _VdbSet;
            }
            catch(Exception ex)
            {
                throw new Exception("Error While getting all record", ex);
            }
            return listofItems;
        }

        public string GetPKName(Object entity)
        {
            string key = string.Empty;
            try
            {
                var type = entity.GetType();
                var temp = type.GetProperties();
                key = temp[0].Name;
            }
            catch
            {
                throw;
            }
            return key;
        }

        public int GetPKValue(Object entity)
        {
            int keyVal = -1;
            try
            {
                string key = GetPKName(entity);
                keyVal = (int)entity.GetType().GetProperty(key).GetValue(entity, null);
            }
            catch
            {
                throw;
            }
            return keyVal;
        }

        


    }
}
