﻿using System;

namespace Corte2
{
    class Inicia
    {
        static void Main(string[] args)
        {
            //Entrada
            Console.Write("Longitud del arreglo : ");
            int longitud = Convert.ToInt32(Console.ReadLine());

            //Valores globales
            Random aleatorio = new Random();
            int[] numeros = new int[longitud];
            int suma = 0;
            int random = 0;

            // Instancia o acceso a otra clase
            var ArregloGenerado = new Arreglo();

            int[] valores = ArregloGenerado.generaElementos(aleatorio, numeros, ref suma, ref random);
            float promedio = ArregloGenerado.obtienePromedio(valores, longitud);
            int[] valores_nuevos = ArregloGenerado.cambiaValores(valores);
            int[] arrayEliminados = ArregloGenerado.eliminaValores(valores);
            
            Console.ReadKey();
        }
    }

    class Arreglo
    {

        // Agrega elementos al arreglo y lo ordena con el método de Inserción
        public int[] generaElementos(Random aleatorio, int[] numeros, ref int suma, ref int random)
        {
            int ordenado = 0;
            int acumulado = 0;

            // Llena las posiciones del arreglo
            for (int index = 0; index < numeros.Length; index += 1)
            {
                random = aleatorio.Next(150, 245);
                numeros[index] = random;

            }

            // Ordena el arreglo una vez sea llenado
            for (int valor=0; valor < numeros.Length; valor+=1){
                ordenado = numeros[valor];
                acumulado = valor - 1;
                while(acumulado >= 0 && numeros[acumulado] > ordenado){
                    numeros[acumulado + 1] = numeros[acumulado];
                    acumulado--;
                }
            }
            
            numeros[acumulado + 1] = ordenado; 

            return numeros;
        }
        // Retorna el promedio de un arreglo
        public float obtienePromedio(int[] valores, int longitud){

            int total = 0;

            foreach (int valor in valores)
            {
                total = total + valor;
            }

            return (float) Convert.ToDouble(total / longitud);
        }

        // Cambia el 50% de los valores de un arreglo de forma aleatoria
        public int[] cambiaValores(int[] valores){

            int porcentaje = valores.Length / 2;
            Random Generado = new Random();
            int posicionesAleatorias = 0;

            for (int index = 0; index <= porcentaje; index+=1){
                posicionesAleatorias = Generado.Next(0, valores.Length);
                valores[posicionesAleatorias] = Generado.Next(250,500);
            }
            
            return valores;
        }

        // Elimina el 10% de los elementos de un array
        public int[] eliminaValores(int[] valores){
            
            float porcentaje = (valores.Length*10)/100;
            Random Generado = new Random();
            int posicionesAleatorias = 0;
            int[] arrayNuevo;

            foreach(int valor in valores){
                Console.Write("Viejo: "+valor + ", ");
            }
            
            for (int index = 0; index < porcentaje; index+=1){
                posicionesAleatorias = Generado.Next(0, valores.Length);
                valores[posicionesAleatorias] = -1;
                if(valores[index] == -1){
                    
                }
            }
            
            foreach(int valor in valores){
                Console.Write("Nuevo: "+valor + ", ");
            }

            return valores;
        }


    }
}
