namespace Lesson_6_three_chicken
{
    internal class Program
    {
        public enum Chickens
        {
            ChickenOne = 1,
            ChickenTwo,
            ChickenThree,
        }

        static void Main(string[] args)
        {
            /*Имеется 3 курицы в клетке.Куриц необходимо кормить зерном и после она высиживает яйцо.
            Возможные действия за один ход:
            - покормить курицу
            - забрать яйцо
            - ничего не делать
            Если курица не накормлена, то она умирает. При условии если курица накормлена, то яйцо высиживается в этот ход и только одно */

            int[,] chickens = { { 1, 0, 0 }, { 2, 0, 0 }, { 3, 0, 0 } };
            int selectChicken = 1;
            int action = 1;
            int countEgg = 0;        //счетчик яиц у курицы
            int countTakeEgg = 0;    //счетчик собранных яиц

            while (true)
            {
                selectChicken = MenuChick(selectChicken);
                Console.WriteLine(selectChicken);


                //if (selectChicken == 0)
                //    break;

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

                //Вызываем меню выбора курицы
                static int MenuChick(int selectChicken)
                {
                    while (true)
                    {
                        Console.WriteLine($"Выберите курицу:\nChickenOne - 1\nChickenTwo - 2\nChickenThree - 3\n");
                        Console.Write("Выполняем действие:");

                        //Выполним проверку введенных данных
                        //Если данные введены некорректно (введен текст или число отличное от пунктов меню)
                        if (!int.TryParse(Console.ReadLine(), out int n) || (n != 1 || n != 2 || n != 3))
                        {
                            Console.Write($"{n}-n, Введите корректные данные. Повторите выбор дейcтвия\n");
                            Console.Write("\nВведите корректные данные. Повторите выбор дейcтвия\n");
                            continue;
                        }
                        else
                            return (n == 1 ? 1 : (n == 2 ? 2 : 3));
                    }
                }
                //Вызываем меню
                static int Menu(int action)
                {
                    while (true)
                    {
                        Console.WriteLine($"Выберите действие22:\nПокормить курицу - 1\nЗабрать яйцо - 2\nНичего не делать - 3\n");
                        Console.Write("Выполняем действие:");

                        //Выполним проверку введенных данных
                        //Если данные введены некорректно (введен текст или число отличное от пунктов меню)
                        if (!int.TryParse(Console.ReadLine(), out int n) || (n != 1 || n != 2 || n != 3))
                        {
                            Console.Write("\nВведите корректные данные. Повторите выбор действия\n");
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