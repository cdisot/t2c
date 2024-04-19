using DataPersistance.Core;
using Domain.Core;
using Domain.T2C;
using Domain.T2C.Repository;

namespace DataPersistance.EntityFramework.Repositories
{
    public class ImagenRepository : BaseRepository<Imagen>, IImagenRepository
    {
        public ImagenRepository(IContext c)
            : base(c)
        {
        }
    }
}