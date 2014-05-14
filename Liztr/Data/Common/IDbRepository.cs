using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liztr.Data.Common
{
    public interface IDbRepository
    {
        T Retrieve<T>(int id) where T : class;
        T Retrieve<T>(int id, string path) where T : class, IEntity;
        T Retrieve<T>(int id, params string[] paths) where T : class, IEntity;

        T Retrieve<T>(Func<T, bool> wherePredicate) where T : class;

        T Retrieve<T>(Func<T, bool> wherePredicate, string property) where T : class;

        T Create<T>(T obj) where T : class;

        int Update<T>(T obj) where T : class;
        int Delete<T>(T obj) where T : class;

        List<T> QueryAll<T>() where T : class;
    }
}
