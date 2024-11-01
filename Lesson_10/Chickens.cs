using System.Xml.Linq;
using System.Collections.Generic;

namespace Lesson_10
{
    internal partial class Program
    {
        public class Chickens
        {
            public string Name { get; private set; }
            public int Live { get; set; }
            public int Satiety { get; set; }
            public int CountEgg { get; set; }
            public int CountTakeEgg { get; set; }

            public Chickens(string name = "Неизвестно", int live = 1, int satiety = 1,int countEgg = 0, int countTakeEgg = 0)
            {
                Name = name; Live = live; Satiety = satiety; CountEgg = countEgg;  CountTakeEgg = countTakeEgg;
            }

        }
    }
}