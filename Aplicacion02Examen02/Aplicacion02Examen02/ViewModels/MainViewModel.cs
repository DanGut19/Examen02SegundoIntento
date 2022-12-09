using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using Xamarin.Forms;

namespace Aplicacion02Examen02.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!(object.Equals(field, newValue)))
            {
                field = (newValue);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public MainViewModel()
        {

            CrearUsuario = new Command(() => {

                Models.Usuario p = new Models.Usuario()
                {

                    Nombre = this.nombre,
                    Apellido = this.apellido,
                    Genero = this.genero,
                    Edad = this.edad,

                };

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "persona.aut");

                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

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
    }
}