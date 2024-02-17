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
        /// 講師 Table
        /// </summary>
        public DbSet<Teacher> Teachers { get; set; }
        /// <summary>
        /// 會員 Table
        /// </summary>
        public DbSet<Member> Members { get; set; }

        /// <summary>
        /// 建立Model 關聯
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>(entity =>
            {
                entity.HasMany(t => t.Classes)
                .WithOne(c => c.Teacher)
                .HasForeignKey(t => t.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
