﻿using Makale.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale.DataAccessLayer
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Liked> Likes { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new DBInitialize());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //FluentAPI

            modelBuilder.Entity<Note>().HasMany(n => n.Comments).WithRequired(c => c.Note).WillCascadeOnDelete(true);

            modelBuilder.Entity<Note>().HasMany(n => n.Likes).WithRequired(c => c.Note).WillCascadeOnDelete(true);
        }
    }
}
