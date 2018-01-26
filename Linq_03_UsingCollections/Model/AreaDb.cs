namespace Linq_03_UsingCollections.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AreaDb : DbContext
    {
        public AreaDb()
            : base("name=AreaDb")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.IP)
                .IsUnicode(false);
        }
    }
}
