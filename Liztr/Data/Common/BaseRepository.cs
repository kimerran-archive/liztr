using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Liztr.Data.Common
{
    /// <summary>
    /// Base repository for Entity Framework
    /// </summary>
    public class BaseRepository
    {
        private IDbContext _ctx;
        public BaseRepository(IDbContext ctx)
        {
            this._ctx = ctx;
        }

        public T Retrieve<T>(int id, string path) where T : class, IEntity
        {
            Func<T, bool> predicate = entity => entity.Id == id;

            var q = _ctx.Set<T>().Include(path);
            return (T)q.Where(predicate).FirstOrDefault();
        }

        public T Retrieve<T>(int id, params string[] paths) where T : class, IEntity
        {
            Func<T, bool> predicate = entity => entity.Id == id;

            var q = _ctx.Set<T>().Include(paths[0]); // on the assumption that paths contains at least 1

            for (int i = 1; i < paths.Length; i++)
            {
                q = q.Include(paths[i]);
            }

            return (T)q.Where(predicate).FirstOrDefault();
        }

        public T Retrieve<T>(int id) where T : class
        {
            T result = _ctx.Set<T>().Find(id);
            return (T)result;
        }

        public T Retrieve<T>(Func<T, bool> wherePredicate, string property) where T : class
        {
            var q = _ctx.Set<T>().Include(property);
            return (T)q.Where(wherePredicate).FirstOrDefault();
        }

        public T Retrieve<T>(Func<T, bool> wherePredicate) where T : class
        {
            var q = _ctx.Set<T>();
            return (T)q.Where(wherePredicate).FirstOrDefault();
        }

        public T Create<T>(T obj) where T : class
        {
            try
            {
                _ctx.Set<T>().Add(obj);
                _ctx.SaveChanges();
                return obj;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }


        }

        public int Update<T>(T obj) where T : class
        {
            try
            {
                _ctx.Set<T>().Attach(obj);
                _ctx.Entry(obj).State = EntityState.Modified;
                _ctx.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public int Delete<T>(T obj) where T : class
        {
            try
            {
                DbSet<T> set = _ctx.Set<T>();
                set.Attach(obj);
                set.Remove(obj);
                _ctx.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public List<T> QueryAll<T>() where T: class
        {
            return _ctx.Set<T>().ToList<T>();
        }
    }
}