using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aplicacion02Examen02.Models
{
    [Serializable]
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public double Edad { get; set; }

        public ObservableCollection<Compra> lista_compra { get; set; } = new ObservableCollection<Compra>();
        public ObservableCollection<Direccion> lista_direccion { get; set; } = new ObservableCollection<Direccion>();
        public ObservableCollection<Targeta_Credito> lista_Targeta_Credito { get; set; } = new ObservableCollection<Targeta_Credito>();

        internal string toString()
        {
            throw new NotImplementedException();
        }
    }
}
