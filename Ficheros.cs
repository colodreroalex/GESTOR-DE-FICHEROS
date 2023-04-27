using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ej4
{
    public static class Ficheros
    {
        private const string ORIGEN = "G:\\Mi unidad\\Programacion\\Ficheros\\";
        private const string DESTINO = "G:\\Mi unidad\\Programacion\\OtrosFicheros\\";

        public static string[] CargarListaFicheros(Selector accion) //seleccionamos accion para indicar donde cargaremos los ficheros
        {
            //RECURSOS
            string[] lista = null;

            //PROCESO
            switch (accion)
            {
                case Selector.copiar:
                case Selector.mover:
                    
                    lista = Directory.GetFiles(ORIGEN);//--> ORIGEN
                    break;
                case Selector.eliminar:
                    
                    lista = Directory.GetFiles(DESTINO, "*.bak");

                    if (Directory.Exists(DESTINO) == true)
                    {
                        Directory.Delete(DESTINO, true);
                    }

                    break;
            }

            //SALIDA
            return lista; 
        }


        //public static IEnumerable<string> CargarListaFicheros(Selector accion)
        //{
        //    IEnumerable<string> listaFicheros = null;

        //    switch (accion)
        //    {
        //        case Selector.copiar:
        //        case Selector.mover:
        //            listaFicheros = Directory.EnumerateFiles(ORIGEN);
        //            break; 

        //        case Selector.eliminar:
        //            listaFicheros = Directory.EnumerateFiles(DESTINO, "*.bak");
        //            break; 
        //    }
        //    return listaFicheros; 
        //}




        public static void Copiar(string fichero)
        {
            string destino;

            

            destino = fichero.Replace(ORIGEN, DESTINO);
            destino = fichero.Replace("txt", "bak");

            //copia del fichero
            File.Copy(fichero, destino  , true);
        }

        public static void Mover(string fichero)
        {
            
            File.Move(fichero, DESTINO + $"\\{SeleccionarNombre(fichero)}" ); 
        }

        public static string SeleccionarNombre(string fichero)
        {
            Console.Clear();
            string nombre;
            Console.WriteLine($"Que nombre quieres que tenga este fichero --> {fichero}?: ");
            nombre = Console.ReadLine();

            return nombre; 
        }
    }
}
