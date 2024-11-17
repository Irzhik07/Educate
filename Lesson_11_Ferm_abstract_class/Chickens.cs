using System.Reflection.Metadata.Ecma335;
using static Lesson_11.Program;

namespace Lesson_11
{
    public class Chickens : Animals
    {
        public int CountEgg { get; set; }
        public int CountTakeEgg { get; set; }

        public Chickens(string name, bool live = true, int satiety = 1) : base(name, live, satiety)
        {
            CountEgg = 0;
            CountTakeEgg = 0;
        }

        //Кормим курочек
        public void FeedChickens()
        {
            CountEgg += 1;
            Satiety += 1;

            if (Satiety == 2 || Satiety == 1)
            {
                OnSatietyChanged($"Уровень сытости курочки {Name} = {Satiety}. Если сейчас забрать яйцо, то курочка погибнет. Покормите еще курочку");
            }
        }

        //Переопределяем метод базового класса Animals
        //Проверяем уровень сытости курочек и вызываем событие SatietyChanged с помощью метода OnSatietyChanged
        internal override bool CheckSatietyAnimals()
        {
            if (Satiety <= 0)
            {
                return Live = false;
            }
            if (Satiety == 2 || Satiety ==1)
            {
                OnSatietyChanged($"Уровень сытости курочки {Name} = {Satiety}. Если сейчас не покормить курочку, то она погибнет");
            }
            return Live;
        }

        protected override void OnSatietyChanged(string message)
        {
            base.OnSatietyChanged(message);
            Console.WriteLine(message);
        }

        //Собираем яица
        public void TakeEggChickens()
        {
            if (CountEgg == 0)
            {
                Console.WriteLine("Курочки еще не снесли яица. Покормите курочек");
                return;
            }

            CountTakeEgg += 1;
            CountEgg -= 1;
            Satiety -= 2;
        }
    }
}