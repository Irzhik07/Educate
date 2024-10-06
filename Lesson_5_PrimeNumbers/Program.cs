using System;
using System.Diagnostics.Metrics;

namespace Lesson_5_PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string primeStr = "";  //строка простых чисел

            Console.Write("Введите положительное число N:");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n > 0)
                {
                    //Определяем последовательность простых чисел до указанного числа N, сформировав массив prime
                    string[] prime = PrimeNumb(n, primeStr).Split(',');
                    Console.Write($"Укажите номер искомого простого числа: ");
                    try
                    {
                        if (int.TryParse(Console.ReadLine(), out int search))
                            Console.WriteLine($"{prime[search]}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else
                    Error();
            }
            else
                Error();

            //Определяем последовательность простых чисел до указанного числа N
            static string PrimeNumb(int primeNumb, string primeStrn)
            {
                for (int i = 1; i <= primeNumb; i++)
                {
                    int count = 0; //счетчик деления числа i
                    for (int j = 1; j <= primeNumb; j++)
                    {
                        if (i % j == 0)
                            count++;
                    }
                    //Если счетчик <=2, то число простое. 
                    //Записываем его в строку primeStrn
                    if (count <= 2)
                        primeStrn += i.ToString() + ',';
                }
                //возвращаем строку с последовательностью простых чисел
                return primeStrn;
            }

            //Выводим сообщение об ошибке
            static void Error()
            {
                Console.WriteLine("Введены некорректные данные.Повторите попытку.");
            }
        }
    }
}