using System.Diagnostics.Metrics;

namespace Lesson_10
{
    internal partial class Program
    {
        public class Cows : Ferm
        {
            public bool Live { get; set; }
            public int Satiety { get; set; }
            public int VolumeMilk { get; set; }
            public int VolumeTakeMilk { get; set; }
            public Cows(string name = "Неизвестно", bool live = true, int satiety = 1, int volumeMilk = 0, int volumeTakeMilk = 0)
            {
                Name = name; Live = true; Satiety = satiety; VolumeMilk = volumeMilk; VolumeTakeMilk = volumeTakeMilk;
            }

            public int CheckSatiety()
            {
                return Satiety;
            }        

        }
    }
}