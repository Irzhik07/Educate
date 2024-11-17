using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static Lesson_11.Program;

namespace Lesson_11
{
    public class Program
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

            Ferm ferm = new Ferm();
            ferm.AddAnimals();

            while (exit)
            {
                action = Menu();

                switch (action)
                {
                    case 1:
                        ferm.FeedAnimals("chickens"); //кормим курочек
                        break;
                    case 2:
                        ferm.TakeEggChickens(); //собираем яица
                        break;
                    case 3:
                        ferm.FeedAnimals("cows"); //кормим коровок
                        break;
                    case 4:
                        ferm.TakeMilkCows(); //собираем молоко
                        break;
                    case 5:
                        ferm.FeedAnimals("all"); //кормим всех животных
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