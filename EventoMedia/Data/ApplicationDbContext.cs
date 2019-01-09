using System;
using System.Collections.Generic;
using System.Text;
using EventoMedia.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventoMedia.Models;

namespace EventoMedia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
       
    }
        public DbSet<Event> Events { get; set; }

        public DbSet<OrganiserRating> OrganiserRatings { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<EventAddress> EventAddresses { get; set; }

        public DbSet<EventPost> EventPosts { get; set; }

        public DbSet<TagEvent> TagEvents { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public virtual DbSet<UserEvent> UserEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TagEvent>()
               .HasKey(te => new { te.TagID, te.EventID });
            modelBuilder.Entity<TagEvent>()
                .HasOne(te => te.Tag)
                .WithMany(t => t.TagEvents)
                .HasForeignKey(te => te.TagID);
            modelBuilder.Entity<TagEvent>()
                 .HasOne(te => te.Event)
                .WithMany(e => e.TagEvents)
                .HasForeignKey(te => te.EventID);

            modelBuilder.Entity<UserEvent>()
                .HasKey(ue => new { ue.UserID, ue.EventID });
            modelBuilder.Entity<UserEvent>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ue => ue.UserID);
            modelBuilder.Entity<UserEvent>()
                .HasOne(ue => ue.Event)
                .WithMany(ev => ev.UserEvents)
                .HasForeignKey(ue => ue.EventID);



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EventoMedia.Models.HomeViewModel> HomeViewModel { get; set; }
    }
}
