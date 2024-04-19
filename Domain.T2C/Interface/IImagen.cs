using System;
using Domain.Core;

namespace Domain.T2C.Interface
{
    public interface IImagen:IEntity
    {
        string PathImagen{ get; set; }
        /// <summary>
        /// Nombre del tipo de imagen, nombre del tipo de categoria(Compañia, Categoria, etc)
        /// </summary>
        string NameType { get; set; }

        /// <summary>
        /// Nombre de la categoria : si la categoria es Compañia, ponerle el nombre de la compañia
        /// </summary>
        string Category { get; set; }

        /// <summary>
        /// Tipo de equipo que se le pone la marca
        /// </summary>
        string Type { get; set; }

        Guid IdEquipo { get; set; }



    }
}