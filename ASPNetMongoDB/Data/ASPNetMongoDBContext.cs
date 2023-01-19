using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNetMongoDB.Models;

namespace ASPNetMongoDB.Data
{
    public class ASPNetMongoDBContext : DbContext
    {
        public ASPNetMongoDBContext (DbContextOptions<ASPNetMongoDBContext> options)
            : base(options)
        {
        }

        public DbSet<ASPNetMongoDB.Models.Kund> Kund { get; set; } = default!;
    }
}
