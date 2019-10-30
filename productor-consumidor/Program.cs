using System;
using System.Threading;

namespace productor_consumidor
{
    class Program
    {
        static Random numaleatorio = new Random(); // para generar un numero random
        static int posicionarr = 0;
        static int ultimaposicionarr = 0;
        static int[] arrproducto = new int[30];

        static void Productor() // comenzara a trabajar cuando el turno sea 0
        {
            int producto = numaleatorio.Next(1,7);
            //ultimaposicionarr = posicionarr;

            if(EstaLleno() == 30)
            {
                Console.WriteLine("Esta lleno");
                posicionarr = 0;
            }
            else
            {
                for (int a = 0; a < producto; a++)
                {
                    arrproducto[posicionarr] = 1;
                    posicionarr++;

                    if (posicionarr > 29)
                    {
                        posicionarr = 0;
                    }
                }

                if (posicionarr > 29)
                {
                    posicionarr = 0;
                }
            }
            
        }

        static void Consumidor() // comenzara a trabajar cuando el turno sea 1
        {
            int producto = numaleatorio.Next(1,7);

            if (EstaVacio() != 30)
            {
                if (ultimaposicionarr > 0)
                    ultimaposicionarr--;
                for (int a = 0; a < producto; a++)
                { 
                    arrproducto[ultimaposicionarr] = 0;
                    ultimaposicionarr++;

                    if (ultimaposicionarr > 29)
                    {
                        ultimaposicionarr = 0;
                    }
                }

                if (ultimaposicionarr > 29)
                {
                    ultimaposicionarr = 0;
                }
            }
            else
            {
                ultimaposicionarr = 0;
            }
            
        }

        static int EstaLleno()
        {
            int contador = 0;

            for (int a = 0; a < 30; a++)
            {
                if( arrproducto[a] == 1)
                {
                    contador++;
                }
            }

            return contador;
        }

        static int EstaVacio()
        {
            int contador = 0;

            for( int a = 0; a < 30; a++)
            {
                if( arrproducto[a] == 0)
                {
                    contador++;
                }
            }

            return contador;
        }

        static void ImprimirProducto()
        {
            for( int a  = 0; a < 30; a++)
                Console.Write("{0}  ", arrproducto[a]);

        }

        static void Main(string[] args)
        {
            int turno;
            int vuelta = 0;
            
            do
            {
                turno = numaleatorio.Next(0, 2);
                Console.WriteLine( "Vuelta: {0}",vuelta);

                if (turno == 0)
                {
                    Console.WriteLine("Turno del Productor");
                    Productor();
                }
                else
                {
                    Console.WriteLine("Turno del Consumidor");
                    Consumidor();
                }

                ImprimirProducto();
                Console.WriteLine("");
                Console.WriteLine("");
                vuelta++;
                Thread.Sleep(2000);

            }while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
        }
    }
}