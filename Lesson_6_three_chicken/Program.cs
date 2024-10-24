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

            int live = 1;            //статус жизни (1 - жива, 0 - мертва)
            int countEgg = 0;        //счетчик яиц у курицы
            int countTakeEgg = 0;    //счетчик собранных яиц
            
            int[,] chickens = { { 1, live, countEgg, countTakeEgg }, { 2, live, countEgg, countTakeEgg }, { 3, live, countEgg, countTakeEgg } }; //массив курочек

            int selectChicken = 0;   //выбор курицы
            int action = 0;          //выбор действия

            string filePath = @"Z:\I.P.Kuznetsova\";
            string fileName = "GameChickens.txt";
            string fullPath = Path.Combine(filePath, fileName);
            FileInfo fileInfo = new FileInfo(fullPath);
            if (!fileInfo.Exists)
                fileInfo.Create();
            if (fileInfo.IsReadOnly)
                Console.WriteLine("Проверьте Ваши права доступа к файлу. Отсутствуют права на изменение.\nРезультат игры не будет записан в файл");

            while (true)
            {
                selectChicken = MenuChick();
                Console.WriteLine($"Выбрана курица - {Enum.GetName(typeof(Chickens),selectChicken)}");

                if (selectChicken == 0)
                    break;

                action = Menu();
                Console.WriteLine($"Выбрано действие - {action}");

                if (action == 0)
                    break;

                switch (action)
                {
                    case 1:
                        chickens[selectChicken-1, 2] += 1;     //увеличиваем счетчик яиц у выбранной курицы
                        Statistics(chickens, selectChicken); //выводим статистику
                        continue;
                    case 2:
                        if (chickens[selectChicken - 1, 2] < 1)
                        {
                            Console.WriteLine($"\nКурица еще не выседела яйцо. Продолжайте играть\n");
                            continue;
                        }
                        chickens[selectChicken - 1, 2] -= 1;    //уменьшаем счетчик яиц у курицы
                        chickens[selectChicken - 1, 3] += 1;    //увеличиваем счтчик собранных яиц
                        Statistics(chickens, selectChicken);//выводим статистику
                        continue;
                    case 3:;
                        Statistics(chickens, selectChicken);//выводим статистику
                        Console.WriteLine($"\nВы не покормили курицу. Она погибла\n");  //тут бы добавить обработку с измененим кол-ва куриц в игре...
                        action = 0;
                        RecordFile(chickens, fileInfo);
                        break;
                }

                //Вызываем меню выбора курицы
                static int MenuChick()
                {
                    Console.WriteLine($"Выберите курицу:\nChickenOne - 1\nChickenTwo - 2\nChickenThree - 3\n");
                    return CheckInput();   //Выполним проверку введенных данных
                }

                //Вызываем меню действий
                static int Menu()
                {
                    Console.WriteLine($"Выберите действие:\nПокормить курицу - 1\nЗабрать яйцо - 2\nНичего не делать - 3\n");
                    return CheckInput();   //Выполним проверку введенных данных
                }

                //Выводим статистику по кол-ву яиц
                static void Statistics(int[,] chickens, int selectChickens)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\nКол-во яиц у курицы - {chickens[selectChickens-1,2]}\nКол-во забранных яиц - {chickens[selectChickens-1, 3]}\n");
                    Console.ResetColor();
                }

                //Проверка на ввод данных
                static int CheckInput()
                {
                    while (true)
                    {
                        int result;
                        bool check = int.TryParse(Console.ReadLine(), out result);
                        if (check && result < 4 && result > 0 )
                        {
                            return (result == 1 ? 1 : (result == 2 ? 2 : 3));
                        }
                        else
                        {
                            Console.Write("\nВведите корректные данные. Повторите выбор дейcтвия\n");
                            continue;
                        }
                    }
                }

                //Запись результатов игры в файл
                static void RecordFile(int[,] chickens, FileInfo fileInfo)
                {
                    using (StreamWriter writer = fileInfo.CreateText())
                    {
                        writer.WriteLine($"Результаты игры:");
                        writer.WriteLine($"Для курицы - {chickens[0, 0]}, Кол-во яиц у курицы - {chickens[0, 2]}, Кол-во забранных яиц - {chickens[0, 3]}");
                        writer.WriteLine($"Для курицы - {chickens[1,0]}, Кол-во яиц у курицы - {chickens[1, 2]}, Кол-во забранных яиц - {chickens[1, 3]}");
                        writer.WriteLine($"Для курицы - {chickens[2,0]}, Кол-во яиц у курицы - {chickens[2, 2]}, Кол-во забранных яиц - {chickens[2, 3]}");
                        writer.WriteLine("Конец");
                    }
                }
            }
        }
    }
}