using System;
using System.Collections.Generic;

namespace OrderRange
{
    public class OrderRange
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese sólo números enteros separados por coma:");
            var entrada = Console.ReadLine();
            List<int> lstNumeros = new List<int>();
            string resultado;
            var lstCadena = entrada.Split(',');
            var iNumero = 0;

            for (int i = 0; i <= lstCadena.Length - 1; i++)
            {
                if (int.TryParse(lstCadena[i], out iNumero))
                {
                    lstNumeros.Add(iNumero);
                }
            }
            resultado = Build(lstNumeros);
            Console.WriteLine(resultado);
            Console.ReadLine();
        }

        public static string Build(List<int> lista)
        {
            string salida = string.Empty;
            string strPares = string.Empty;
            string strImpares = string.Empty;
            List<int> pares = new List<int>();
            List<int> impares = new List<int>();


            foreach (int numero in lista)
            {
                if (Convert.ToBoolean((numero % 2 == 0 ? true : false)))
                {
                    pares.Add(numero);
                    pares.Sort();
                }
                else
                {
                    impares.Add(numero);
                    impares.Sort();
                }
            }
            foreach (var item in pares)
                strPares = strPares + item + ",";
            foreach (var item in impares)
                strImpares = strImpares + item + ",";

            if (strPares.Length > 0) { strPares = strPares.Remove(strPares.Length - 1); }
            if (strImpares.Length > 0) { strImpares = strImpares.Remove(strImpares.Length - 1); }

            salida = "[" + strImpares + "]" + "[" + strPares + "]";
            return salida;
        }
    }
}
