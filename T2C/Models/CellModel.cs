using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.T2C.Interface;

namespace T2C.Models
{

    public class CellModel
    {
        public CellModel()
        {
            Id = Guid.NewGuid();
            Imagens = new List<IImagen>();
            Date = DateTime.Now;
            FrecuencyProcessor =" ";
            Processor = " ";
            Size = -1;
            Year = DateTime.Now.Year;
        }


        [Key]
        public Guid Id { get; set; }


        [Display(Name = @"Nombre")]
        public string Name { get; set; }

        [Display(Name = @"Modelo")]
        public string Model { get; set; }

        [Display(Name = @"Categoria")]
        public string Category { get; set; }

        [Display(Name = @"Tipo")]
        public string Type { get; set; }

        [Display(Name = @"Compañía")]
        public string Company { get; set; }

        [Display(Name = @"Precio($)")]
        public double Price { get; set; }


        [Display(Name = @"Enciende")]
        public bool Start { get; set; }


        [Display(Name = @"Condición")]
        public string Condition { get; set; }


        [Display(Name = @"Memoria")]
        public int Memory { get; set; }

        [Display(Name = @"Generación")]
        public string Generation { get; set; }

        [Display(Name = @"Procesador")]
        public string Processor { get; set; }

        [Display(Name = @"Tamaño")]
        public double Size { get; set; }

        [Display(Name = @"Año")]
        public int Year { get; set; }

        public int Visits { get; set; }

        public virtual IEnumerable<IImagen> Imagens { get; set; }


        [Display(Name = @"Fecha")]
        public DateTime Date { get; set; }

         [Display(Name = @"Frecuencia Procesador")]
        public string FrecuencyProcessor { get; set; }







    }
}