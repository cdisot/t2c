using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using DataPersistance.EntityFramework.EntityConfig;
using Domain.Core;
using Domain.T2C;

namespace DataPersistance.EntityFramework
{
    public class CoreDbContext : DbContext, IContext
    {
        public CoreDbContext()
            : base("context")
        {
          //  Database.SetInitializer(new CreateDatabaseIfNotExists<CoreDbContext>());
        }

        public IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public TEntity Add<TEntity>(TEntity item) where TEntity : class
        {
            return Set<TEntity>().Add(item);
        }

        public void Update<TEntity>(TEntity item) where TEntity : class
        {
            Set<TEntity>().Attach(item);
        }

        public void Delete<TEntity>(TEntity item) where TEntity : class
        {
            Set<TEntity>().Remove(item);
        }

        public IUnitOfWork BeginTransaction()
        {
            return new EntityFrameworkTransaction(Database.BeginTransaction());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //TODO: Creacion de la BD
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();



            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(1000));


            //Cell
            modelBuilder.Configurations.Add(new CellConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new ImageConfig());

            modelBuilder.Entity<Cell>();
            modelBuilder.Entity<UserCell>();
            modelBuilder.Entity<Imagen>();

/*
            modelBuilder.Entity<Imagen>().
                HasRequired<Cell>(s => s.).
                WithMany(s => (ICollection<Imagen>)s.Imagens).
                HasForeignKey(s => s.IdCell);

            */

            //modelBuilder.Entity<ServiceTur>().
            //    HasRequired<Address>(s=> s.Address).
            //    WithMany(s=> (ICollection<ServiceTur>) s.ListService).
            //    HasForeignKey(s=>s.IdAddress);



            base.OnModelCreating(modelBuilder);
        }








    }
}
