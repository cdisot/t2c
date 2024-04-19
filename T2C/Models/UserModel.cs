using System;
using System.ComponentModel.DataAnnotations;

namespace T2C.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Display(Name = @"Usuario")]
        public string UserName { get; set; }


        [Display(Name = @"Contraseña")]
        
        public string Password { get; set; }

        
    }
}