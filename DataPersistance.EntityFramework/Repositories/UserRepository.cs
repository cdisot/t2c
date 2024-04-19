using DataPersistance.Core;
using Domain.Core;
using Domain.T2C;
using Domain.T2C.Repository;

namespace DataPersistance.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<UserCell>, IUserRepository
    {
        public UserRepository(IContext c)
            : base(c)
        {
        }
    }
}