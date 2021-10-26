using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Data.Configurations;
using UdemyNLayerProject.Data.Seeds;

namespace UdemyNLayerProject.Data
{
  public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

       public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products { get; set; }
       public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Veritabanımdaki entitylerim tabloya dönüşürken modeldeki propertylerimin uzunluğu ne olacak , bir primary key olacak mı gibi özellikler burda ayarlanır.
            // Örn;
            // modelBuilder.Entity<Product>().HasKey(x => x.ID);

            //Buradaki tanımlamaları best practice açısından ayrı bir configuration classı oluşturup orada yazıp burada çağıracağım.  

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] {1,2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] {1,2 }));

            //Örnek olması açısından Person sınıfımı burada tanımlayacağım.Best Practice açısından ayrı biryerde yazılması daha uygundur
            //Aşağıdaki gibi her entity'mi buraya yazsaydım burası kod kalabalığı olacak ve okunmaz hale gelecekti
            modelBuilder.Entity<Person>().HasKey(x=>x.ID);
            modelBuilder.Entity<Person>().Property(x=>x.ID).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.Surname).HasMaxLength(100);

        }
    }
}
