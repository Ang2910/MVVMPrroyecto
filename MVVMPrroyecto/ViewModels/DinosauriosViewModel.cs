using GalaSoft.MvvmLight.Command;
using MVVMPrroyecto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; 


namespace MVVMPrroyecto.ViewModels 
{
    public class DinosauriosViewModel : INotifyPropertyChanged 
    {
        public ObservableCollection<Dinosaurio> Dinosaurios { get; set; } = new ObservableCollection<Dinosaurio>();

        public Dinosaurio? Dinosaurio { get; set; } 
        public string? Mensaje { get; set; }
        public ICommand AgregarCommand { get; set; }

        public ICommand EliminarCommand { get; set; } 
        public ICommand CancelarCommand { get; set; }
        public ICommand MostrarVistaVerCommand { get; set; }
        public string Vista { get; set; } = "ver";            


        public DinosauriosViewModel() 
        {
            Abrir(); 
            AgregarCommand = new RelayCommand(Agregar);
            CancelarCommand = new RelayCommand(Cancelar);
            MostrarVistaVerCommand = new RelayCommand<string>(MostrarVistaVer);
            EliminarCommand = new RelayCommand(Eliminar); 
        }

        private void MostrarVistaVer(string obj) 
        {
            Vista = obj;   

            if(obj == "agregar") 
            {
                Dinosaurio = new Dinosaurio(); 
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vista)));    
        }

        private void Cancelar()
        {
            Dinosaurio = null; 
            Vista = "ver";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vista")); 
        }

        void Agregar() 
        {
            if(Dinosaurio != null) 
            {

                Mensaje = ""; 
            
            if(string.IsNullOrWhiteSpace(Dinosaurio.Nombre)) 
            {
                Mensaje = "Escriba el nombre del dinosaurio";  
            }

            if(string.IsNullOrWhiteSpace(Dinosaurio.Descripcion))
                {
                    Mensaje = "Escriba la descripcion del dinosaurio"; 
                }


            if(Mensaje == "")
                {
                    Dinosaurios.Add(Dinosaurio);
                    Vista = "ver";
                    Guardar(); 
                }


                  


                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));  
        }
    }

    void Eliminar()
        {
        if(Dinosaurio != null)
            {
                Dinosaurios.Remove(Dinosaurio);
                Guardar();
                MostrarVistaVer("ver");  
            }


        }
        void Modificar()
        {

        }

        void Guardar()
        {
            var json = JsonConvert.SerializeObject(Dinosaurios);
            System.IO.File.WriteAllText("dinosaurios.json", json);  
        }
        void Abrir()
        {
            if(File.Exists("dinosaurios.json"))
            {
                var json = File.ReadAllText("dinosaurios.json");
                var datos = JsonConvert.DeserializeObject<ObservableCollection<Dinosaurio>>(json);

                if(datos == null)
                {
                    Dinosaurios = new ObservableCollection<Dinosaurio>();
                }
                else {
                    Dinosaurios = datos;
                }
            }

            
        }
           

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
