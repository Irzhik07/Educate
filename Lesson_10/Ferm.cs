using static Lesson_10.Program;

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

        public class Ferm
         {
            public List<Cows> cows = new List<Cows>();
            public List<Chickens> chickens = new List<Chickens>();
            
            public void AddAnimals()
            {
                foreach (var number in Enum.GetValues(typeof(SelectAnimals)))
                {
                    chickens.Add(new Chickens("Chicken" + number?.ToString()));
                    cows.Add(new Cows("Cow" + number?.ToString()));
                }
            }

            public void ClearChickens()
            {
                chickens.Clear();
                Console.WriteLine("11111111");
            }

            public void StatisticsPrint()
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                foreach (var chicken in chickens)
                    Console.WriteLine($"Имя:{chicken.Name}  Статус жизни: {chicken.Live} Уровень сытости: {chicken.Satiety} Кол-во яиц - {chicken.CountEgg} Кол-во собранных яиц - {chicken.CountTakeEgg}");
                foreach (var cow in cows)
                    Console.WriteLine($"Имя:{cow.Name}  Статус жизни: {cow.Live} Кол-во молока - {cow.VolumeMilk} Кол-во собранного молока - {cow.VolumeTakeMilk}");
                Console.ResetColor();
            }
        }
    }
}