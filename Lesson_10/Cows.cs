using System.Diagnostics.Metrics;

namespace Lesson_10
{
    internal partial class Program
    {
        public class Cows
        {
            public string Name { get; private set; }
            public int Live { get; set; }
            public int VolumeMilk { get; set; }
            public int VolumeTakeMilk { get; set; }

            public Cows(string name = "Неизвестно", int live = 1, int volumeMilk = 0, int volumeTakeMilk = 0)
            {
                Name = name; Live = live; VolumeMilk = volumeMilk; VolumeTakeMilk = volumeTakeMilk;
            }
        }
    }
}