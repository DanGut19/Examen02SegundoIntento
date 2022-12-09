using Aplicacion02Examen02.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Aplicacion02Examen02.ViewModels
{
    public class ViewModelUsuario : INotifyPropertyChanged
    {
        public ViewModelUsuario()
        {

            CrearUsuario = new Command(() => {

                Usuario p = new Usuario()
                {

                    Nombre = this.nombre,
                    Apellido = this.apellido,
                    Genero = this.genero,
                    Edad = this.edad,

                };

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Usuario.aut");

                Stream Compra = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(Compra, p);
                Compra.Close();

            });

            AbrirLista = new Command(() => {

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Usuario.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                Usuario = (ObservableCollection<Usuario>)formatter.Deserialize(archivo);
                archivo.Close();

                Resultado = "";

                foreach (Usuario tmp in Usuario)
                {

                    Resultado += tmp.toString() + "\r\n";

                }


            });


        }


        string nombre;

        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string apellido;

        public string Apellido
        {
            get => apellido;
            set
            {
                apellido = value;
                var arg = new PropertyChangedEventArgs(nameof(apellido));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string genero;

        public string Genero
        {
            get => genero;
            set
            {
                genero = value;
                var arg = new PropertyChangedEventArgs(nameof(Genero));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double edad;

        public double Edad
        {
            get => edad;
            set
            {
                edad = value;
                var arg = new PropertyChangedEventArgs(nameof(edad));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public Command CrearUsuario { get; }
        public Command AbrirLista { get; }
        public string Resultado { get; private set; }
        public ObservableCollection<Usuario> Usuario { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
