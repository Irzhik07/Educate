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
            public List<Chickens> chickens = new List<Chickens>();
            public List<Cows> cows = new List<Cows>();
            public string Name { get; set; }
            public void AddAnimals()
            {
                foreach (var number in Enum.GetValues(typeof(SelectAnimals)))
                {
                    chickens.Add(new Chickens("Chicken" + number?.ToString()));
                    cows.Add(new Cows("Cow" + number?.ToString()));
                }
            }

            //Проверяем уровень сытости курочек
            //Если он <= 0, то курочки погибают
            public void CheckSatietyChickens()
            {
                int s = 1;
                foreach (var chicken in chickens)
                    s = chicken.CheckSatiety();      

                if (s <= 0)
                {
                    chickens.Clear();
                    Console.WriteLine("Сытость курочек <0. Курочки погибли");
                }
            }

            //Проверяем уровень сытости коровок
            //Если он <= 0, то коровки погибают
            public void CheckSatietyCows()
            {
                int s = 1;
                foreach (var cow in cows)
                    s = cow.CheckSatiety();

                if (s <= 0)
                {
                    cows.Clear();
                    Console.WriteLine("Сытость коровок <0. Коровки погибли");
                }
            }
        }   
    }
}