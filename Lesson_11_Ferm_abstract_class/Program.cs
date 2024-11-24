using Lesson_11_Ferm_abstract_class;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
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
            bool exit = false;

            ILogger logger = new CombineLogger(new ILogger[] { new LoggerInfo(), new LoggerInfoFile(@"Z:\I.P.Kuznetsova\GameFerm.txt") });
            //ILogger loggerInfo = new LoggerInfo();

            Ferm ferm = new Ferm();
            ferm.AddAnimals();

            while (exit == false)
            {
                action = Menu(logger);

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
                            RecordFile(ferm,logger);
                            logger.LogInfo("Игра окончена. До новых встреч!\n");
                            Console.ReadKey();
                            exit = true;
                            break;
                        }
                }

                //Вызываем меню действий
                static int Menu(ILogger logger)
                {
                    logger.LogInfo($"Выберите действие:\nПокормить курочек - 1\nСобрать яица у курочек - 2\nКормить коровок - 3\nПодоить коровок - 4" +
                        $"\nПокормить всех - 5\nПосмотреть статистику фермы - 6\nВыйти и сохранить результат - 7");

                    return CheckInput(logger);   //Выполним проверку введенных данных
                }

                //Проверка на ввод данных
                static int CheckInput(ILogger logger)
                {
                    while (true)
                    {
                        int result;
                        bool check = int.TryParse(Console.ReadLine(), out result);
                        if (check && result < 8 && result > 0)
                            return result;
                        else
                        {
                            logger.LogInfo("\nВведите корректные данные. Повторите выбор дейcтвия\n");
                            continue;
                        }
                    }
                }

                //Запись результатов игры в файл
                static void RecordFile(Ferm ferm, ILogger logger)
                {
                        logger.LogInfo($"Результаты игры:");
                        foreach (var chicken in ferm.chickens)
                            logger.LogInfo($"Имя:{chicken.Name}  Статус жизни: {chicken.Live} Уровень сытости: {chicken.Satiety} Кол-во яиц - {chicken.CountEgg} Кол-во собранных яиц - {chicken.CountTakeEgg}");
                        foreach (var cow in ferm.cows)
                            logger.LogInfo($"Имя:{cow.Name}  Статус жизни: {cow.Live} Уровень сытости: {cow.Satiety} Кол-во молока - {cow.VolumeMilk} Кол-во собранного молока - {cow.VolumeTakeMilk}");
                        logger.LogInfo("Конец");
                }
            }
        }
    }
}