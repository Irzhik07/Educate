using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Lesson_5_ChickenEgg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Имеется 1 курица в клетке.Курицу необходимо кормить зерном и после она высиживает яйцо.
            Возможные действия за один ход:
            -покормить курицу
            - забрать яйцо
            - ничего не делать
            Если курица не накормлена, то она умирает. За раз положить допускает 3 - 5 зерен(на вашу фантазию.
            При условии если курица накормлена, то яйцо высиживается в этот ход и только одно */

            int action = 1;
            int countEgg = 0;        //счетчик яиц у курицы
            int countTakeEgg = 0;    //счетчик собранных яиц
            int exit = 0;

            while (true)
            {
                if (action == 0)
                    break;

                action = Menu(action);

                switch (action)
                {
                    case 1:
                            countEgg++;                         //увеличиваем счетчик яиц у курицы
                            Statistics(countEgg, countTakeEgg); //выводим статистику
                            continue;
                    case 2:
                            if (countEgg < 1)
                            {
                                Console.WriteLine($"\nКурица еще не выседела яйцо. Продолжайте играть\n");
                                continue;
                            }
                            countEgg--;                         //увеличиваем счетчик яиц у курицы
                            countTakeEgg++;                     //увеличиваем счтчик собранных яиц
                            Statistics(countEgg, countTakeEgg); //выводим статистику
                            continue;
                    case 3:
                            Console.WriteLine($"\nВы не покормили курицу. Она погибла. Игра окончена\n");
                            action = 0;
                            break;
                }

                //Вызываем меню
                static int Menu(int actionMenu)
                {
                    while (true)
                    {
                        Console.WriteLine($"Выберите действие:\nПокормить курицу - 1\nЗабрать яйцо - 2\nНичего не делать - 3\n");
                        Console.Write("Выполняем действие:");

                        //Выполним проверку введенных данных
                        //Если данные введены некорректно (введен текст или число отличное от пунктов меню)
                        if (!int.TryParse(Console.ReadLine(), out int n) ||  (n != 1 || n != 2 || n != 3))
                        {
                            Console.Write("\nВведите корректные данные. Повторите выбор дейтсвия\n");
                            continue;
                        }
                        else
                            return (n == 1 ? 1 : (n == 2 ? 2 : 3));
                    }
                    
                }
                //Выводим статистику по кол-ву яиц
                static void Statistics(int countEgg, int countTakeEgg)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\nКол-во яиц у курицы - {countEgg}\nКол-во забранных яиц - {countTakeEgg}\n");
                    Console.ResetColor();
                }
            }
        }
    }
}