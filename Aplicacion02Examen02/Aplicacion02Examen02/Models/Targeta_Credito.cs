using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion02Examen02.Models
{
    [Serializable]
    public class Targeta_Credito
    {
        public string nombre { get; set; }
        public double codigo { get; set; }
        public double contrasenia { get; set; }

    }
}
