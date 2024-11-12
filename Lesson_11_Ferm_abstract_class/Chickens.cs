using System.Reflection.Metadata.Ecma335;
using static Lesson_11.Program;

namespace Lesson_11
{
    public class Chickens : Animals
    {
        public int CountEgg { get; set; }
        public int CountTakeEgg { get; set; }

        public Chickens(string name = "Неизвестно", bool live = true, int satiety = 1, int countEgg = 0, int countTakeEgg = 0)
        {
            Name = name; Live = true; Satiety = satiety; CountEgg = countEgg; CountTakeEgg = countTakeEgg;
        }

        //Проверяем уровень сытости курочек
        //Если он <= 0, то курочки погибают
        public virtual void CheckSatietyAnimals()
        {
            int s = 1;
            foreach (var chicken in chickens)
                s = CheckSatiety();

            if (s <= 0)
            {
                chickens.Clear();
                Console.WriteLine("Сытость курочек <0. Курочки погибли");
            }
        }

        public int CheckSatiety()
        {
            return Satiety;
        }
    }
}
}