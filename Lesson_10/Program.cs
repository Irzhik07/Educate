using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Lesson_10
{
    internal partial class Program
    {
        public enum SelectAnimals
        {
            One = 1,
            Two,
            Three,
        }

        static void Main(string[] args)
        {
            string filePath = @"Z:\I.P.Kuznetsova\";
            string fileName = "GameChickens.txt";
            string fullPath = Path.Combine(filePath, fileName);
            FileInfo fileInfo = new FileInfo(fullPath);
            if (!fileInfo.Exists)
                fileInfo.Create();
            if (fileInfo.IsReadOnly)
                Console.WriteLine("Проверьте Ваши права доступа к файлу. Отсутствуют права на изменение.\nРезультат игры не будет записан в файл");

            //Создаем список куриц и коров
            List<Chickens> chickens = new List<Chickens>();
            List<Cows> cows = new List<Cows>();

            //Добавляем курочек и коровок в соответствующий список в кол-ве констант перечисления SelectAnimals (т.е. в кол-ве 3-х штук)
            foreach (var number in Enum.GetValues(typeof(SelectAnimals)))
            {
                chickens.Add(new Chickens("Chicken" + number?.ToString(), 1, 0, 0));
                cows.Add(new Cows("Cow" + number?.ToString(), 1, 0, 0));
            }
            //foreach (var chicken in chickens)
            //{
            //    Console.WriteLine($"Имя: {chicken.Name}  Статус жизни: {chicken.Live} Кол-во яиц {chicken.CountEgg} Кол-во собранных яиц {chicken.CountTakeEgg}");
            //}
            //foreach (var cow in cows)
            //{
            //    Console.WriteLine($"Имя: {cow.Name}  Статус жизни: {cow.Live} Кол-во яиц {cow.VolumeMilk} Кол-во собранных яиц {cow.VolumeTakeMilk}");
            //}


            //while (true) 
            //{
            //    {
            //        selectChicken = MenuChick();
            //        Console.WriteLine($"Выбрана курица - {Enum.GetName(typeof(Chickens), selectChicken)}");
            //    }
            //    //Вызываем меню выбора курицы
            //    static int MenuChick()
            //{
            //    Console.WriteLine($"Выберите курицу:\nChickenOne - 1\nChickenTwo - 2\nChickenThree - 3\n");
            //    return CheckInput();   //Выполним проверку введенных данных
            //}

            ////Вызываем меню действий
            //static int Menu()
            //{
            //    Console.WriteLine($"Выберите действие:\nПокормить курицу - 1\nЗабрать яйцо - 2\nНичего не делать - 3\n");
            //    return CheckInput();   //Выполним проверку введенных данных
            //}

            ////Выводим статистику по кол-ву яиц
            //static void Statistics(int[,] chickens, int selectChickens)
            //{
            //    Console.ForegroundColor = ConsoleColor.DarkRed;
            //    Console.WriteLine($"\nКол-во яиц у курицы - {chickens[selectChickens - 1, 2]}\nКол-во забранных яиц - {chickens[selectChickens - 1, 3]}\n");
            //    Console.ResetColor();
            //}

            ////Проверка на ввод данных
            //static int CheckInput()
            //{
            //    while (true)
            //    {
            //        int result;
            //        bool check = int.TryParse(Console.ReadLine(), out result);
            //        if (check && result < 4 && result > 0)
            //        {
            //            return (result == 1 ? 1 : (result == 2 ? 2 : 3));
            //        }
            //        else
            //        {
            //            Console.Write("\nВведите корректные данные. Повторите выбор дейcтвия\n");
            //            continue;
            //        }
            //    }
            //}

            ////Запись результатов игры в файл
            //static void RecordFile(int[,] chickens, FileInfo fileInfo)
            //{
            //    using (StreamWriter writer = fileInfo.CreateText())
            //    {
            //        writer.WriteLine($"Результаты игры:");
            //        writer.WriteLine($"Для курицы - {chickens[0, 0]}, Кол-во яиц у курицы - {chickens[0, 2]}, Кол-во забранных яиц - {chickens[0, 3]}");
            //        writer.WriteLine($"Для курицы - {chickens[1, 0]}, Кол-во яиц у курицы - {chickens[1, 2]}, Кол-во забранных яиц - {chickens[1, 3]}");
            //        writer.WriteLine($"Для курицы - {chickens[2, 0]}, Кол-во яиц у курицы - {chickens[2, 2]}, Кол-во забранных яиц - {chickens[2, 3]}");
            //        writer.WriteLine("Конец");
            //    }
            //}
        }
    }
}