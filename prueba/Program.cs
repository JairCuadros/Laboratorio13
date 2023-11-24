using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba
{
    internal class Program
    {
        static string[] respuestas = new string[100];
        static int cantidadPersonas = 0;
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                print("================================\n" +
                  "Encuestas de Calidad\n" +
                  "================================\n" +
                  "1: Realizar Encuesta\n" +
                  "2: Ver datos registrados\n" +
                  "3: Eliminar un dato\n" +
                  "4: Ordenar datos de menor a mayor\n" +
                  "5: Salir\n" +
                  "================================\n" +
                  "Ingrese una opción: \n");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:RealizarEncuesta();break;
                        case 2:MostrarResultados();break;
                        case 3:EliminarRespuesta();break;
                        case 4:OrdenarRespuestas();break;
                        case 5:Console.Clear(); print("¡Hasta luego!");break;
                        default:Console.Clear(); print("Opción no válida. Inténtelo de nuevo."+ 
                            "\nPrecione cualquier tecla para continuar"); Console.ReadKey(); break;
                    }
                }
                else
                {
                    Console.Clear();
                    print("Por favor, ingrese un número válido."+
                          "\nPresione cualquier tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
                
            } while (opcion != 5);
        }
        static void RealizarEncuesta()
        {
            Console.Clear();
            print("===================================\n" +
                      "Nivel de Satisfacción\n" +
                      "===================================\n" +
                      "¿Qué tan satisfecho está con la atención de nuestra tienda?\n" +
                      " \n" +
                      "1: Nada satisfecho\n" +
                      "2: No muy satisfecho\n" +
                      "3: Tolerable\n" +
                      "4: Satisfecho\n" +
                      "5: Muy satisfecho\n" +
                      "===================================\n" +
                      "Ingrese una opción: \n");
            string respuesta = Console.ReadLine();
            if (EsRespuestaValida(respuesta))
            {
                respuestas[cantidadPersonas] = respuesta;
                cantidadPersonas++;
                Console.Clear();
                print("===================================\n" +
                      "Nivel de Satisfacción\n" +
                      "===================================\n" +
                      "¡Gracias por participar!\n" +
                      "===================================\n" +
                      "Presione cualquier tecla para regresar al menú ...\n");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                print("Respuesta no válida. Por favor, ingrese un número del 1 al 5."+
                    "\nPresione cualquier tecla para continuar.");
                Console.ReadKey();
                RealizarEncuesta();
            }
            Console.Clear();
        }
        static void MostrarResultados()
        {
            Console.Clear();
            print("===================================\n"+
                "Ver datos registrados\n"+
                "===================================" );
            datosRegistrados();
            Console.WriteLine("");
            print($"\n{ContarOcurrencias("1")} personas: Nada satisfecho\n" +
                  $"{ContarOcurrencias("2")} personas: No muy satisfecho\n" +
                  $"{ContarOcurrencias("3")} personas: Tolerable\n" +
                  $"{ContarOcurrencias("4")} personas: Satisfecho\n" +
                  $"{ContarOcurrencias("5")} personas: Muy satisfecho\n" +
                  "Presione cualquier tecla para regresar al menú");
            Console.ReadKey();
            Console.Clear();
        }
        static void EliminarRespuesta()
        {
            Console.Clear();
            print("===================================\n" +
                  "Eliminar un dato\n" +
                  "===================================");
            datosRegistrados();
            print("\n==================================="+
                  "\nIngrese la posición a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < cantidadPersonas)
            {
                for (int i = indice; i < cantidadPersonas - 1; i++)
                {
                    respuestas[i] = respuestas[i + 1];
                }
                cantidadPersonas--;
                print("===================================\n" +
                      "Respuesta eliminada exitosamente\n");
            }
            else
            {
                print("Índice no válido. Inténtelo de nuevo.");
            }
            datosRegistrados();
            print("\nPresione cualquier tecla para volver al menú\n");
            Console.ReadKey();
            Console.Clear();
        }
        static void OrdenarRespuestas()
        {
            Console.Clear();
            print("===================================\n" +
                  "Ordenar datos\n" +
                  "===================================");
            datosRegistrados();
            print("\nPresione cualquier tecla para ordenar");
            Array.Sort(respuestas, 0, cantidadPersonas);
            print("");
            Console.ReadKey();
            datosRegistrados();
            print("\nPresione cualquier tecla para volver al menú");
            Console.ReadKey();
            Console.Clear();
        }

        static bool EsRespuestaValida(string respuesta)
        {
            return respuesta == "1" || respuesta == "2" || respuesta == "3" || respuesta == "4" || respuesta == "5";
        }
        static int ContarOcurrencias(string opcion)
        {
            int contador = 0;
            for (int i = 0; i < cantidadPersonas; i++)
            {
                if (respuestas[i] == opcion)
                {
                    contador++;
                }
            }
            return contador;
        }
        static void print(string text)
        {
            Console.WriteLine(text);
        }
        static void datosRegistrados()
        {
            for (int i = 0; i < cantidadPersonas; i++)
            {
                Console.Write($"[{respuestas[i]}]");

                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}