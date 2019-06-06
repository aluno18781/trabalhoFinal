using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace noticiasAuto.Models { 
    public class NoticiasDB : DbContext
    {
        public NoticiasDB() : base("NoticiasDBConnectionString") { }
        

        public DbSet<Equipas> Equipas { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<Pilotos> Pilotos { get; set; }
        public DbSet<utilizadores> Utilizadores { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }

}