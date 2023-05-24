using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tarifim.Data.Entities.BaseEntity;

namespace Tarifim.Data.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<FoodEntity> Foods { get; set; }
    }
    public class CategoryEntityConfiguration : BaseConfiguration<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
            builder.Property(x => x.ImagePath).IsRequired(false);

            builder.HasData
                (
                new CategoryEntity {Id=1,Name="AnaYemekler",ImagePath= "anayemek-0f491d7b-b43e-4d17-b3fc-14b4c63643ae.jpg" },
                 new CategoryEntity { Id = 2, Name = "Çorbalar", ImagePath = "corbalar-472f802b-1c0c-4080-b326-ede3f85e7d95.jpg" },
                  new CategoryEntity { Id = 3, Name = "Mezeler", ImagePath = "mezeler-4729d6fd-a77c-4325-9195-21e029d2e96f.jpg" },
                   new CategoryEntity { Id = 4, Name = "Tatlılar", ImagePath = "tatlılar-b64ccedc-54a3-45fe-83ed-c598b4534ba1.jpg" }
                );
        }
    }
}
