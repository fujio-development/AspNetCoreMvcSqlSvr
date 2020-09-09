using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvcSqlSvr.Models;

namespace AspNetCoreMvcSqlSvr.Data
{
    public class MvcShohinContext : DbContext
    {
        public MvcShohinContext(DbContextOptions<MvcShohinContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetCoreMvcSqlSvr.Models.Shohin> Shohin { get; set; }
    }
}
