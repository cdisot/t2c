using DataPersistance.Core;
using Domain.Core;
using Domain.T2C;
using Domain.T2C.Repository;

namespace DataPersistance.EntityFramework.Repositories
{
   public  class CellRepository:BaseRepository<Cell>,ICellRepository
    {
       public CellRepository(IContext c)
        : base(c)
    {
    }
    }
}
