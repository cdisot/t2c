using Domain.Core;
using Domain.T2C.Interface;

namespace Domain.T2C
{
   public  class UserCell:Entity,IUser
    {
       public string UserName { get; set; }

       public string Password { get; set; }
      
    }
}