using Domain.Core;

namespace Domain.T2C.Interface
{
    public interface IUser:IEntity
    {
        string UserName { get; set; }
        string Password { get; set; }

    }
}