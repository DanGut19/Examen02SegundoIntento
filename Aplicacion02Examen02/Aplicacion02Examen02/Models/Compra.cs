using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion02Examen02.Models
{
    [Serializable]
    public class Compra
    {
        public string Producto { get; set; }
        public double Precio { get; set; }
    }
}
