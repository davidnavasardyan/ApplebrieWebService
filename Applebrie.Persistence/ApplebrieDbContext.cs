using Applebrie.Domain;
using Microsoft.EntityFrameworkCore;

namespace Applebrie.Persistence
{
    public class ApplebrieDbContext : DbContext
    {
        #region DBSet's
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        #endregion

        #region Ctor
        public ApplebrieDbContext(DbContextOptions options) : base(options) { }
        #endregion

        #region Relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasOne<UserType>(t => t.UserType).WithMany(u => u.Users).HasForeignKey(fk => fk.UserTypeId);
        }
        #endregion
    }
}
