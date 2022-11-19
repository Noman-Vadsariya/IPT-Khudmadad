using Khudmadad_Backend.Efcore;
using Microsoft.EntityFrameworkCore;

namespace Khudmadad_Backend.EfCore
{
    public class Ef_DataContext : DbContext
    {
        public Ef_DataContext(DbContextOptions<Ef_DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasIndex(u => u.userName)
                .IsUnique();

            modelBuilder.Entity<Users>()
                .HasOne(p => p.Role)
                .WithMany(b => b.users)
                .HasForeignKey(p => p.roleId);

            modelBuilder.Entity<Gig>()
                .HasOne(p => p.Creator)
                .WithMany(b => b.gig)
                .HasForeignKey(p => p.creatorId);
            
            modelBuilder.Entity<Offers>()
                .HasKey(nameof(Offers.gigId), nameof(Offers.freelancerId));
            
            modelBuilder.Entity<Offers>()
                .HasOne<Users>(p => p.freelancer)
                .WithMany(b => b.offer)
                .HasForeignKey(p => p.freelancerId);
            
            modelBuilder.Entity<Offers>()
                .HasOne<Gig>(p => p.gig)
                .WithMany(b => b.offer)
                .HasForeignKey(p => p.gigId);

        }

        public DbSet<Roles> roles { get; set; }

        public DbSet<Users> users { get; set; }

        public DbSet<Gig> gig { get; set; }

        public DbSet<Offers> offer { get; set; }
    }
}
