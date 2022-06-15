using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1JuliePro_DataAccess.Data
{
    public class JulieProDbContext : DbContext
    {
        
        public JulieProDbContext(DbContextOptions<JulieProDbContext> options) : base(options)
        {
        }
        
        //public virtual DbSet<Movie> Movies { get; set; 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (modelBuilder == null)
                return;

            modelBuilder.GenerateData();
        }

    }
}
