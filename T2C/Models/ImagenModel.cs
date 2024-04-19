using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace T2C.Models
{
    public class ImagenModel
    
    {
        public ImagenModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

       public Guid IdEquipo { get; set; }

        [Display(Name = @"Url")]
        public string PathImagen { get; set; }

         [Display(Name = @"Equipo")]
        public string Type { get; set; }

        /// <summary>
        /// Nombre del tipo de imagen, nombre del tipo de categoria(Compa�ia, Categoria, etc)
        /// </summary>
        [Display(Name = @"Tipo")]
        public string Category { get; set; }

        /// <summary>
        /// Nombre de la categoria : si la categoria es Compa�ia, ponerle el nombre de la compa�ia
        /// </summary>
        [Display(Name = @"Nombre")]
        public string NameType { get; set; }
        
        
        
        [Display(Name = @"Image")]
        public string Name { get; set; }

        [DisplayName("Seleccionar para subir im�gen")]
        public IEnumerable<HttpPostedFileBase> File { get; set; }
      
    }
}