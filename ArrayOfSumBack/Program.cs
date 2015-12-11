using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfSum
{
    class Program
    {
        //Дана двумерная квадратная матрица. Получить массив b1 … bn , где bi - 
        //это сумма элементов, предшествующих последнему отрицательному  элементу i-той строки (если все элементы строки неотрицательны, то принять bi=-1)
        static void Main(string[] args)
        {
            Console.Write("Введите порядок квадратной матрицы (число строк): ");
            int order = int.Parse(Console.ReadLine());
            int[,] array = new int[order, order];
            int[] arraySumma = new int[order];
            int summa;

            //Enter elements of the array
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    Console.Write("Enter array[" + i + "],[" + j + "] : ");
                    int element = int.Parse(Console.ReadLine());
                    array[i, j] = element;
                    Console.WriteLine("array[" + i + "],[" + j + "] is " + array[i, j]);
                }
            }

            //При решении задачи предусмотреть вывод массива в виде таблицы (каждую строку таблицы отделять при выводе на экран переводом на новую строку

            Console.WriteLine("Your 2D array is: ");
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    if (j < (order - 1))
                    {
                        Console.Write(array[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(array[i, j]);
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();

            int indexNegativeElement;
            for (int i = 0; i < order; i++)
            {
                indexNegativeElement = -1;
                for (int j = (order - 1); j >= 0; j--)
                {
                    //первый попавшийся отрицательный элемент с конца массива и будет наш искомый
                    //после него тут же начинаем считать сумму предшествующих ему элементов
                    if (array[i, j] < 0)
                    {
                        indexNegativeElement = j;
                        summa = 0;

                        for (int k = (j - 1); k >= 0; k--)
                        {
                            summa = summa + array[i, k];
                        }
                        arraySumma[i] = summa;
                        Console.WriteLine("into the array[" + i + "] = " + arraySumma[i]);
                        break;
                    }

                    //если отрицательный элемент в строке будет стоять в самом ее начале
                    else if (indexNegativeElement == 0)
                    {
                        arraySumma[i] = 0;
                    }

                    //если в строке нет отрицательных элементов
                    else if (indexNegativeElement == -1)
                    {
                        arraySumma[i] = -1;
                    }
                }
                Console.WriteLine("arraySumma[" + i + "] = " + arraySumma[i]);
                Console.ReadKey();
            }

            //Вывод результата
            Console.WriteLine("Результирующий массив b: ");
            for (int i = 0; i < order; i++)
            {
                Console.Write(arraySumma[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
