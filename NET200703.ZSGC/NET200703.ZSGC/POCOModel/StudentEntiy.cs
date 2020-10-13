namespace NET200703.ZSGC.POCOModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentEntiy : DbContext
    {
        public StudentEntiy()
            : base("name=StudentEntiy")
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GType> GType { get; set; }
        public virtual DbSet<Studio> Studio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(e => e.gName)
                .IsUnicode(false);

            modelBuilder.Entity<GType>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<GType>()
                .HasMany(e => e.Game)
                .WithRequired(e => e.GType)
                .HasForeignKey(e => e.gTid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Studio>()
                .Property(e => e.sName)
                .IsUnicode(false);

            modelBuilder.Entity<Studio>()
                .Property(e => e.sTel)
                .IsUnicode(false);

            modelBuilder.Entity<Studio>()
                .HasMany(e => e.Game)
                .WithRequired(e => e.Studio)
                .HasForeignKey(e => e.gSId)
                .WillCascadeOnDelete(false);
        }
    }
}
