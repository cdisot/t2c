using System;
using Domain.Core;
using Domain.T2C.Interface;

namespace Domain.T2C
{
    public class Imagen:Entity,IImagen
    {
        public string PathImagen { get; set; }
        public string NameType { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public Guid IdEquipo { get; set; }
    }
}