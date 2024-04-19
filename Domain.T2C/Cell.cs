using System;
using System.Collections.Generic;
using Domain.Core;
using Domain.T2C.Interface;

namespace Domain.T2C
{
    public class Cell:Entity,ICell
    {
        public string Model { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }
        public bool Start { get; set; }
        public string Condition { get; set; }
        public virtual IEnumerable<IImagen> Imagens { get; set; }
        public int Memory { get; set; }
        public int Visits { get; set; }
        public DateTime? Date { get; set; }
        public string  Category { get; set; }
        public string Type { get; set; }
        public string Generation { get; set; }
        public string Processor { get; set; }
        public  double Size { get; set; }
        public int Year { get; set; }
        public string FrecuencyProcessor { get; set; }
       
    }
}
