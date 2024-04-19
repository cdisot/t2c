using System;
using System.ComponentModel.DataAnnotations;

namespace T2C.Models
{
    public class CategoryModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = @"Campo Vacio")]
        [Display(Name = @"Nombre")]
        public string Name { get; set; }
    }
}