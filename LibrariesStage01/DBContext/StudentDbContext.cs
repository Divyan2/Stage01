using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibrariesStage01.Models;

namespace LibrariesStage01.DBContext
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<StudentDbContext>(null); 
        }
        public DbSet<Student> Students { get; set; }
    }
}
