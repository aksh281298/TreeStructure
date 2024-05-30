using Microsoft.EntityFrameworkCore;
using TreeStructure.Models;

namespace TreeStructure
{
    public class DBCtx : DbContext
    {
        public DBCtx(DbContextOptions<DBCtx> options) : base(options)
        { }
        public DbSet<ParentType> ParentTypes { get; set; }
        public DbSet<ParentSubType> ParentSubTypes { get; set; }
    }
}
