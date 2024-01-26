using LibrariesStage01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesStage01.DBContext
{
    public class DefaultDbContext : DbContext
    {
        //initialization
        public DefaultDbContext() : base("DBCS")
        {
            Database.SetInitializer<DefaultDbContext>(null);
        }

        public DbSet<SampleModel> sampleModels { get; set; }
    }
}
