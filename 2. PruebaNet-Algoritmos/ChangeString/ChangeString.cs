using System;
using System.Linq;

namespace ChangeString
{
    public class ChangeString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la cadena de texto a modificar:");
            var entrada = Console.ReadLine();
            Console.WriteLine(Build(entrada));
            Console.ReadLine();
        }

        public static string Build(string entrada)
        {
            char letra;
            bool esLetra;
            string salida = "";
                        
            foreach (char c in entrada)
            {
                letra = c;
                if (letra == 'z')
                {
                    letra = 'a';
                    salida = salida + letra.ToString();
                    continue;
                }
                else if (letra == 'Z')
                {
                    letra = 'A';
                    salida = salida + letra.ToString();
                    continue;
                }
                else if(letra == 'n')
                {
                    letra = 'ñ';
                    salida = salida + letra.ToString();
                    continue;
                }
                else if (letra == 'N')
                {
                    letra = 'Ñ';
                    salida = salida + letra.ToString();
                    continue;
                }
                else if (letra == 'ñ')
                {
                    letra = 'o';
                    salida = salida + letra.ToString();
                    continue;
                }
                else if (letra == 'Ñ')
                {
                    letra = 'O';
                    salida = salida + letra.ToString();
                    continue;
                }

                esLetra = letra.ToString().Any(x => char.IsLetter(x));
                if (esLetra)
                {
                    letra++;
                    if (letra.ToString().Any(char.IsUpper))
                    {
                        salida = salida + (letra++).ToString().ToUpper();
                    }
                    else
                    {
                        salida = salida + (letra++).ToString();
                    }
                }
                else
                {
                    salida = salida + c.ToString();
                }
            }
            return salida;
        }
    }
}