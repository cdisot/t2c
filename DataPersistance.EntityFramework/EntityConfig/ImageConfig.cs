using System.Data.Entity.ModelConfiguration;
using Domain.T2C;

namespace DataPersistance.EntityFramework.EntityConfig
{
    public class ImageConfig : EntityTypeConfiguration<Imagen>
    {
        public ImageConfig()
        {
            HasKey(a => a.Id);
            Property(n => n.Name).
                IsRequired().
                HasMaxLength(30);
        }
    }
}