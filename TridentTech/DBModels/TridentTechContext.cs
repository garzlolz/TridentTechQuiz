using Microsoft.EntityFrameworkCore;

namespace TridentTech.DBModels
{
    /// <summary>
    /// Tables
    /// </summary>
    public class TridentTechContext : DbContext
    {
        public TridentTechContext(DbContextOptions options) : base(options) { }
        /// <summary>
        /// 課程 Table
        /// </summary>
        public DbSet<Class> Classes { get; set; }
        /// <summary>
        /// 會員 Table
        /// </summary>
        public DbSet<Member> Members { get; set; }
        /// <summary>
        /// 會員 Table
        /// </summary>
        public DbSet<ClassSelection> ClassSelectiones { get; set; }

        /// <summary>
        /// 建立Model 關聯
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Member>(entity =>
            {
                entity.HasMany(t => t.Classes)
                .WithOne(c => c.Member)
                .HasForeignKey(t => t.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ClassSelection>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberClasses)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.MemberClasses)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
