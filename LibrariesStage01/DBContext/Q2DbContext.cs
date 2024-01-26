using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibrariesStage01.Models;

namespace LibrariesStage01.DBContext
{
    public class Q2DbContext : DbContext
    {
        public Q2DbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<Q2DbContext>(null);
        }

        public DbSet<TableLogic> tableLogics { get; set; }
    }
}
