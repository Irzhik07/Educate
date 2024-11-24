using Lesson_11;
using Lesson_11_Ferm_abstract_class;
using System.Diagnostics.Metrics;

namespace Lesson_11
{
    public class Cows : Animals
    {
        ILogger logger = new CombineLogger(new ILogger[] { new LoggerInfo(), new LoggerInfoFile(@"Z:\I.P.Kuznetsova\GameFerm.txt") });

        public int VolumeMilk { get; set; }
        public int VolumeTakeMilk { get; set; }
        public Cows(string name, bool live = true, int satiety = 1) : base(name, live, satiety)
        {
            VolumeMilk = 0;
            VolumeTakeMilk = 0;
        }

        //Кормим коровок
        public void FeedCows()
        {
            VolumeMilk += 1;
            Satiety += 1;

            if (Satiety == 2 || Satiety == 1)
            {
                OnSatietyChanged($"Уровень сытости коровки {Name} = {Satiety}. Если сейчас забрать молоко, то коровка погибнет. Покормите еще коровку");
            }
        }
        //Собираем молоко
        public void TakeMilkCows()
        {
            if (VolumeMilk == 0)
            {
                logger.LogInfo("Коровки еще не дали молока. Покормите коровок");
                return;
            }
            VolumeMilk += 1;
            VolumeTakeMilk -= 1;
            Satiety -= 2;
        }

        //Переопределяем метод базового класса Animals
        //Проверяем уровень сытости коровок и вызываем событие SatietyChanged с помощью метода OnSatietyChanged
        internal override bool CheckSatietyAnimals()
        {
            if (Satiety <= 0)
            {
                return Live = false;
            }
            if (Satiety == 2 || Satiety == 1)
            {
                OnSatietyChanged($"Уровень сытости коровки {Name} = {Satiety}. Если сейчас не покормить коровку, то она погибнет");
            }
            return Live;
        }

        protected override void OnSatietyChanged(string message)
        {
            base.OnSatietyChanged(message);
            logger.LogInfo(message);
        }
    }
}