using Liztr.Data.Common;
using Liztr.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Liztr.Data.Repository
{
    public class LiztrDbContext : DbContext, IDbContext
    {
        public LiztrDbContext() : base("LiztrDb")
        {

        }
        public DbSet<Event> Events { get; set; }

        //public  DbSet<T> Set<T>() where T : class
        //{
        //    return base.Set<T>();
        //}

        //public DbEntityEntry<T> Entry<T>(T entity) where T : class
        //{
        //    return base.Entry<T>(entity);
        //}

        //public int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    base.Dispose();
        //}

    }
}