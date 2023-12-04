using Domain.Models;
using Domain.Models.Chat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contexts
{
    public class CoreContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Joined> Joineds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>()
                .HasKey(g => g.ID);

            modelBuilder.Entity<Joined>()
                .HasKey(j => j.IDUser);
            modelBuilder.Entity<Joined>()
                .HasKey(j => j.IDGroup);

            modelBuilder.Entity<Message>()
                .HasKey(m => m.ID);

            modelBuilder.Entity<Auth>()
                .HasKey(a => a.ID);
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);
        }

        public CoreContext(DbContextOptions<CoreContext> options):base(options)
        {
            
        }
    }
}
