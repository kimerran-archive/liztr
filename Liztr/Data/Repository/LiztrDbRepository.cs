using Liztr.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liztr.Data.Repository
{
    public class LiztrDbRepository : BaseRepository, IDbRepository
    {
        private IDbContext _ctx;
        public LiztrDbRepository(IDbContext ctx)
            : base(ctx)
        {
            this._ctx = ctx;          
        }

    }
}