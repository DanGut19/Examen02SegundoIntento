using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion02Examen02.Models
{
    [Serializable]
    public class Direccion
    {
        public string Region { get; set; }
        public string Colonia { get; set; }
        public string Sona { get; set; }
        public double Codigo_Postal { get; set; }

    }
}
