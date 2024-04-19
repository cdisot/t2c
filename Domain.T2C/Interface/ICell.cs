using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain.T2C.Interface
{
    public interface ICell : IEntity
    {
        string Model { get; set; }
        string Company { get; set; }
        double Price { get; set; }
        bool Start { get; set; }
        string Condition { get; set; }
        int Visits { get; set; }
        DateTime? Date { get; set; }
        string Category { get; set; }
        IEnumerable<IImagen> Imagens { get; set; }
        int Memory { get; set; }
        string Type { get; set; }
        string Generation { get; set; }
        string Processor { get; set; }
        double Size { get; set; }
        int Year { get; set; }
        string FrecuencyProcessor { get; set; }
      

    }
}
