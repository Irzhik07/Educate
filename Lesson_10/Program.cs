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
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        ferm.StatisticsPrint(); //Выводим статистику по ферме
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

                static void FeedChickens(Ferm ferm)
                {
                    foreach (var chicken in ferm.chickens)
                    {
                        chicken.CountEgg += 1;
                        chicken.Satiety += 1;
                    }
                        
                }

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
                        
                        if (chicken.Satiety < 0)
                        {
                            ferm.ClearChickens();
                            break;
                        }

                        chicken.CountTakeEgg += 1;
                        chicken.CountEgg -= 1;
                        chicken.Satiety -= 2;
                        count +=1;

                    }
                        
                }

                //Запись результатов игры в файл
                static bool RecordFile(Ferm ferm, FileInfo fileInfo, bool exit)
                {
                    using (StreamWriter writer = fileInfo.CreateText())
                    {
                        writer.WriteLine($"Результаты игры:");
                        //writer.WriteLine($"Для курицы - {chickens[0, 0]}, Кол-во яиц у курицы - {chickens[0, 2]}, Кол-во забранных яиц - {chickens[0, 3]}");
                        //writer.WriteLine($"Для курицы - {chickens[1, 0]}, Кол-во яиц у курицы - {chickens[1, 2]}, Кол-во забранных яиц - {chickens[1, 3]}");
                        //writer.WriteLine($"Для курицы - {chickens[2, 0]}, Кол-во яиц у курицы - {chickens[2, 2]}, Кол-во забранных яиц - {chickens[2, 3]}");
                        writer.WriteLine("Конец");
                        return exit = false;
                    }
                }
            }
        }
    }
}