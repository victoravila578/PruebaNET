using System;
using System.Collections.Generic;

namespace MoneyParts
{
    public class MoneyParts
    {
        static void Main(string[] args)
        {
            double[] denominaciones = { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };
            double[] contador = new double[denominaciones.Length];
            Console.WriteLine("Ingrese un valor:");

            try
            {
                int monto = int.Parse(Console.ReadLine());
                var lstCombinaciones = new List<List<double>>();
                lstCombinaciones = Build(denominaciones, contador, 0, monto, lstCombinaciones);

                for (int i = 0; i <= lstCombinaciones.Count - 1; i++)
                {
                    int c = i + 1;
                    Console.WriteLine("[" + string.Join(" , ", lstCombinaciones[i].ToArray()) + "]");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("El valor ingresado debe ser entero.");
            }
            Console.ReadLine();
        }

        public static List<List<double>> Build(double[] lstValores, double[] contador, int iteracion, double monto, List<List<double>> lstCombinaciones)
        {
            if (iteracion >= lstValores.Length)
            {
                var lstCombinacion = new List<double>();
                for (int i = 0; i < lstValores.Length; i++)
                {
                    if (contador[i] != 0)
                    {
                        int conteo = int.Parse(contador[i].ToString());
                        for (int c = 0; c <= conteo - 1; c++)
                        {
                            lstCombinacion.Add(lstValores[i]);
                        }

                    }
                }
                lstCombinaciones.Add(lstCombinacion);

                return lstCombinaciones;
            }
            if (iteracion == lstValores.Length - 1)
            {
                if (monto % lstValores[iteracion] == 0)
                {
                    contador[iteracion] = monto / lstValores[iteracion];
                    lstCombinaciones = Build(lstValores, contador, iteracion + 1, 0, lstCombinaciones);
                }
            }
            else
            {
                for (int i = 0; i <= monto / lstValores[iteracion]; i++)
                {
                    contador[iteracion] = i;
                    lstCombinaciones = Build(lstValores, contador, iteracion + 1, monto - lstValores[iteracion] * i, lstCombinaciones);
                }
            }
            return lstCombinaciones;
        }
    }
}
