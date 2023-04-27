using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej4
{
    internal class pantalla
    {
        public static Selector SeleccionarAccion()
        {
            Selector seleccionar = Selector.salir;
            bool selectorOk = false;

            do
            {
                MenuPrincipal();

                try
                {
                    seleccionar = (Selector)LeerOpcion((byte)Selector.salir, (byte)Selector.eliminar);
                    selectorOk = true; 
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
                finally
                {
                    if (!selectorOk) Pausa(); 
                }
            } while (!selectorOk);

            return seleccionar;
        }

        public static void Pausa()
        {
            Console.WriteLine("Pulse enter para continuar...");
            Console.ReadLine();
        }

        public static void MostrarError(string message)
        {
            Console.WriteLine("ERROR: " + message);
        }

        public static int LeerOpcion(int opmin,int opmax)
        {
            int op;

            op = Convert.ToByte(Console.ReadLine());

            if (op > opmax) throw new Exception("Opcion no valida");

            return op; 
        }

        public static void MenuPrincipal()
        {
            MostrarCabecera(Selector.salir);

            Console.WriteLine("0.- Salir");
            Console.WriteLine("1.-Copiar");
            Console.WriteLine("2.-Mover");
            Console.WriteLine("3.-Eliminar");
            Console.WriteLine("Seleccione accion: ");
        }

        public static void MostrarCabecera(Selector accion)
        {
            Console.Clear();
            Console.WriteLine("*** GESTOR DE FICHEROS ***");
            switch (accion)
            {
                case Selector.copiar:
                    Console.WriteLine("*** COPIAR FICHERO ***");
                    break;
                case Selector.mover:
                    Console.WriteLine("***  MOVER FICHERO ***");
                    break;
                case Selector.eliminar:
                    Console.WriteLine("*** ELIMINAR FICHERO ***");
                    break; 
            }
        }

        //public static void MostrarLista(IEnumerable<string> lista)  //VALIDO
        //{
        //    int i = 1;
        //    Console.WriteLine("\t0 --> Cancelar");

        //    foreach (string fichero in lista)
        //    {
        //        Console.WriteLine($"\t{i} --> {fichero}");
        //        i++;
        //    }
        //}

        public static void MostrarListaOpcion2(string[] lista)  //Los dos son validos porque IENUMERABLE internamente es un array
        {
            int i = 1;
            Console.WriteLine("\t0 --> Cancelar");

            foreach (string fichero in lista)
            {
                Console.WriteLine($"\t{i} --> {fichero}");
                i++;
            }
        }

        public static bool Confirmar(string mensaje)
        {
            bool moverOk = false;
            byte opcion;
            Console.Clear();

            Console.WriteLine(mensaje);
            Console.WriteLine("1.-Si");
            Console.WriteLine("2.-No");
            opcion = Convert.ToByte(Console.ReadLine());


            if (opcion == 1) moverOk = true;
            if (opcion > 2) throw new Exception("LAS OPCIONES SON 1 Y 2");
            
            return moverOk; 
        }
    }
}
