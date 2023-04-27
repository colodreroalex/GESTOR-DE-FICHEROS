using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej4
{
    public enum Selector : byte { salir, copiar, mover, eliminar }

    internal class controladorPrincipal
    {
        public static void Controlador()
        {
            bool salir = false;
            Selector opcion = Selector.salir;

            do
            {
                opcion = pantalla.SeleccionarAccion();

                switch (opcion)
                {
                    case Selector.salir:
                        salir = true;
                        break; 

                        case Selector.copiar:
                        Copiar();
                        break; 

                        case Selector.mover:
                        Move();
                        break;

                        case Selector.eliminar:
                        Eliminar();
                        break; 
                }

            }while(!salir);
        }

        public static void Eliminar()
        {
            throw new NotImplementedException();
        }

        public static void Move()
        {
            //RECURSOS
            string[] listaFicheros = null;
            int i = -1;
            bool correcto = false;

            //1.-SELECCIONAR ARCHIVO A MOVER
            do
            {

                //1.1.-Mostrar la lista de ficheros disponibles
                pantalla.MostrarCabecera(Selector.mover);   
                pantalla.MostrarListaOpcion2(listaFicheros);
                //1.2.-Seleccionar el fichero o cancelar accion

            } while (!correcto);

            

           

            //2.-MOVER EL FICHERO
            //2.1.-Verificar si se ha cancelado la accion
            //2.2.-Solicitar confirmacion de la Accion
            //2.3.-Si confirmacion Aceptada --> Mover el fichero
            

        }

        public static void Copiar()
        {

            //RECURSOS


            //IEnumerable<string> listaFicheros = null;
            string[] ArrayFicheros = null; 
            int indice = -1; 
            bool correcto = false;

            //Cargamos los ficheros en el array
            ArrayFicheros = Ficheros.CargarListaFicheros(Selector.copiar);

            do
            {
                pantalla.MostrarCabecera(Selector.copiar);
                pantalla.MostrarListaOpcion2(ArrayFicheros);

                
                try
                {
                    //indice = pantalla.LeerOpcion(0, (byte)ArrayFicheros.Count()) - 1;
                    indice = pantalla.LeerOpcion
                        ((byte)Selector.salir, (byte)ArrayFicheros.Length) - 1;
                    correcto = true; 
                }
                catch (Exception ex)
                {
                    pantalla.MostrarError(ex.Message);

                }
                finally
                {
                    if (!correcto) pantalla.Pausa();
                }

            } while(!correcto);

            if(indice >= 0) 
            {
                Ficheros.Copiar(ArrayFicheros[indice]);
            }
            
        }
    }
}
