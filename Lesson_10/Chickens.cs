using System.Xml.Linq;
using System.Collections.Generic;
using static Lesson_10.Program;

namespace Lesson_10
{
    internal partial class Program
    {
        public class Chickens : Ferm
        {
            public bool Live { get; private set; }
            public int Satiety { get; set; }
            public int CountEgg { get; set; }
            public int CountTakeEgg { get; set; }

            public Chickens(string name = "Неизвестно", bool live = true, int satiety = 1, int countEgg = 0, int countTakeEgg = 0)
            {
                Name = name; Live = true; Satiety = satiety; CountEgg = countEgg; CountTakeEgg = countTakeEgg;
            }

            public int CheckSatiety()
            {
                return Satiety;
            }

        }
    }
}