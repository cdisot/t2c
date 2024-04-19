//using System.Data.Entity.ModelConfiguration;
//using Domain.Agencia.AgenciaTurismo;

using System.Data.Entity.ModelConfiguration;
using Domain.T2C;

namespace DataPersistance.EntityFramework.EntityConfig
{

    public class CellConfig : EntityTypeConfiguration<Cell>
    {
        public CellConfig()
        {
            HasKey(a => a.Id);
            Property(n => n.Name).
                IsRequired().
                HasMaxLength(30);
        }
    }
}