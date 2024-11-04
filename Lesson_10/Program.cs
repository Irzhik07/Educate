using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static Lesson_10.Program;

namespace Lesson_10
{
    internal partial class Program
    {       
        static void Main(string[] args)
        {
            int action = 0;
            bool exit = true;

            string filePath = @"Z:\I.P.Kuznetsova\";
            string fileName = "GameChickens.txt";
            string fullPath = Path.Combine(filePath, fileName);
            FileInfo fileInfo = new FileInfo(fullPath);
            if (!fileInfo.Exists)
                fileInfo.Create();
            if (fileInfo.IsReadOnly)
                Console.WriteLine("Проверьте Ваши права доступа к файлу. Отсутствуют права на изменение.\nРезультат игры не будет записан в файл");

            Ferm ferm = new ();
            ferm.AddAnimals();

            while (exit)
            {
                action = Menu();

                switch (action)
                {
                    case 1:
                        FeedChickens(ferm);
                        break;
                    case 2:
                        TakeEggChickens(ferm);
                        break;
                    case 3:
                        FeedCows(ferm);
                        break;
                    case 4:
                        TakeMilkCows(ferm);
                        break;
                    case 5:
                        FeedAnimals(ferm);
                        break;
                    case 6:
                        StatisticsPrint(ferm); //Выводим статистику по ферме
                        break;
                    case 7:
                        {
                            exit = RecordFile(ferm, fileInfo, exit);
                            Console.WriteLine("Игра окончена. До новых встреч!");
                            Console.ReadKey();
                            break;
                        }
                }

                //Вызываем меню действий
                static int Menu()
                {
                    Console.WriteLine($"Выберите действие:\nПокормить курочек - 1\nСобрать яица у курочек - 2\nКормить коровок - 3\nПодоить коровок - 4" +
                        $"\nПокормить всех - 5\nПосмотреть статистику фермы - 6\nВыйти и сохранить результат - 7");

                    return CheckInput();   //Выполним проверку введенных данных
                }

                //Проверка на ввод данных
                static int CheckInput()
                {
                    while (true)
                    {
                        int result;
                        bool check = int.TryParse(Console.ReadLine(), out result);
                        if (check && result < 8 && result > 0)
                            return result;
                        else
                        {
                            Console.Write("\nВведите корректные данные. Повторите выбор дейcтвия\n");
                            continue;
                        }
                    }
                }

                //Меню - 1. Кормим курочек
                static void FeedChickens(Ferm ferm)
                {
                    foreach (var chicken in ferm.chickens)
                    {
                        chicken.CountEgg += 1;
                        chicken.Satiety += 1;
                    }
                }

                //Меню - 2. Забираем яица у курочек
                static void TakeEggChickens(Ferm ferm)
                {
                    foreach (var chicken in ferm.chickens)
                    {
                        int count = 1;

                        if (chicken.CountEgg == 0)
                        {
                            Console.WriteLine("Курочки еще не снесли яица. Покормите курочек");
                            break;
                        }

                        chicken.CountTakeEgg += 1;
                        chicken.CountEgg -= 1;
                        chicken.Satiety -= 2;
                            
                        count += 1;

                    }
                    //Проверка уровня сытости курочек
                    //Если уровень < 0, то курочки погибают
                    ferm.CheckSatietyChickens();
                }

                //Меню - 3. Кормим коровок
                static void FeedCows(Ferm ferm)
                {
                    foreach (var cow in ferm.cows)
                    {
                        cow.VolumeMilk += 1;
                        cow.Satiety += 1;
                    }
                }

                //Меню - 4. Забираем молоко у коровок
                static void TakeMilkCows(Ferm ferm)
                {
                    foreach (var cow in ferm.cows)
                    {
                        int count = 1;

                        if (cow.VolumeMilk == 0)
                        {
                            Console.WriteLine("У коровок нет молока. Покормите коровок");
                            break;
                        }

                        cow.VolumeTakeMilk += 1;
                        cow.VolumeMilk -= 1;
                        cow.Satiety -= 2;

                        count += 1;

                    }
                    //Проверка уровня сытости коровок
                    //Если уровень < 0, то коровки погибают
                    ferm.CheckSatietyCows();
                }

                //Меню - 5. Кормим всех животных на ферме
                static void FeedAnimals(Ferm ferm)
                {
                    FeedChickens(ferm);
                    FeedCows(ferm);
                }

                //Вывод статистики фермы на экран
                static void StatisticsPrint(Ferm ferm)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    foreach (var chicken in ferm.chickens)
                        Console.WriteLine($"Имя:{chicken.Name}  Статус жизни: {chicken.Live} Уровень сытости: {chicken.Satiety} Кол-во яиц - {chicken.CountEgg} Кол-во собранных яиц - {chicken.CountTakeEgg}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var cow in ferm.cows)
                        Console.WriteLine($"Имя:{cow.Name}  Статус жизни: {cow.Live} Уровень сытости: {cow.Satiety} Кол-во молока - {cow.VolumeMilk} Кол-во собранного молока - {cow.VolumeTakeMilk}");
                    Console.ResetColor();
                }
                //Запись результатов игры в файл
                static bool RecordFile(Ferm ferm, FileInfo fileInfo, bool exit)
                {
                    using (StreamWriter writer = fileInfo.CreateText())
                    {
                        writer.WriteLine($"Результаты игры:");
                        foreach (var chicken in ferm.chickens)
                            writer.WriteLine($"Имя:{chicken.Name}  Статус жизни: {chicken.Live} Уровень сытости: {chicken.Satiety} Кол-во яиц - {chicken.CountEgg} Кол-во собранных яиц - {chicken.CountTakeEgg}");
                        foreach (var cow in ferm.cows)
                            writer.WriteLine($"Имя:{cow.Name}  Статус жизни: {cow.Live} Уровень сытости: {cow.Satiety} Кол-во молока - {cow.VolumeMilk} Кол-во собранного молока - {cow.VolumeTakeMilk}");
                        writer.WriteLine("Конец");
                        return exit = false;
                    }
                }
            }
        }
    }
}