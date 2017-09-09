using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class MusicStoreDataContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Album> Album { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<AlbumAuthor> AlbumAuthor { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Localize> Localize { get; set; }
        public DbSet<User> User { get; set; }
    }
}