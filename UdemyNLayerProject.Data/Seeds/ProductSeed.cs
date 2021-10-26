using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { ID = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 100, CategoryID = _ids[0] },
                new Product { ID = 2, Name = "Kurşun Kalem", Price = 40.50m, Stock = 200, CategoryID = _ids[0] },
                new Product { ID = 3, Name = "Tükenmez Kalem", Price = 500m, Stock = 300, CategoryID = _ids[0] },
                new Product { ID = 5, Name = "Küçük Boy Defter", Price = 12.50m, Stock = 100, CategoryID = _ids[1] },
                new Product { ID = 6, Name = "Orta Boy Defter", Price = 22.50m, Stock = 150, CategoryID = _ids[1] },
                new Product { ID = 7, Name = "Büyük Boy Defter", Price = 32.50m, Stock = 200, CategoryID = _ids[1] }

                );



        }
    }
}
