using Lesson_11;
using System.Diagnostics.Metrics;

namespace Lesson_11
{
    public class Cows : Animals
    {
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