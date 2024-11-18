using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Lesson_11
{
    public enum SelectAnimals
    {
        One = 1,
        Two,
        Three,
    }
    public class Ferm
    {

        //Создаем списки животных фермы
        public List<Chickens> chickens = new List<Chickens>();
        public List<Cows> cows = new List<Cows>();

        //Добавляем в списки курочек и коровок
        public void AddAnimals()
        {
            foreach (var number in Enum.GetValues(typeof(SelectAnimals)))
            {
                chickens.Add(new Chickens("Chicken" + number?.ToString()));
                cows.Add(new Cows("Cow" + number?.ToString()));
            }
        }

        //Кормим животных
        public void FeedAnimals(string animalsInput)
        {
            switch (animalsInput)
            {
                //Меню - 1. Кормим курочек (animalsInput == chickens)
                case "chickens":
                    foreach (var chicken in chickens)
                        chicken.FeedChickens();
                    break;
                //Меню - 3. Кормим коровок
                case "cows":
                    foreach (var cow in cows)
                        cow.FeedCows();
                    break;
                case "all":
                    foreach (var chicken in chickens)
                        chicken.FeedChickens();
                    foreach (var cow in cows)
                        cow.FeedCows();
                    break;
                default:
                    Console.WriteLine("Неизвестно, кого кормить");
                    break;
            }
        }

        //Меню - 2. Забираем яица у курочек и проверяем уровень сытости.
        public void TakeEggChickens()
        {
            bool live = true;
            foreach (var chicken in chickens)
            {
                chicken.TakeEggChickens();
                live = chicken.CheckSatietyAnimals();
            }

            if (live == false)
            {
                //Если уровень жизни - false (сытость курочек <= 0), то курочки погибли
                Console.WriteLine($"Сытость курочек <0. Курочки погибли");
                chickens.Clear();
            }
        }

        //Меню - 4. Забираем молоко у коровок и проверяем уровень сытости.
        public void TakeMilkCows()
        {
            bool live = true;
            foreach (var cow in cows)
            {
                cow.TakeMilkCows();
                live = cow.CheckSatietyAnimals();
            }

            if (live == false)
            {
                //Если уровень жизни - false (сытость коровок <= 0), то коровки погибли
                Console.WriteLine($"Сытость коровок <0. Коровки погибли");
                cows.Clear();
            }
        }

        //Вывод статистики фермы на экран
        public void StatisticsPrint()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var chicken in chickens)
                Console.WriteLine($"Имя:{chicken.Name}  Статус жизни: {chicken.Live} Уровень сытости: {chicken.Satiety} Кол-во яиц - {chicken.CountEgg} Кол-во собранных яиц - {chicken.CountTakeEgg}");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var cow in cows)
                Console.WriteLine($"Имя:{cow.Name}  Статус жизни: {cow.Live} Уровень сытости: {cow.Satiety} Кол-во молока - {cow.VolumeMilk} Кол-во собранного молока - {cow.VolumeTakeMilk}");
            Console.ResetColor();
        }

    }
}