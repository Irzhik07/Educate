using static Lesson_11.Program;

namespace Lesson_11
{
    public abstract class Animals
    {
        public string Name { get; set; }
        public bool Live { get; set; }
        public int Satiety { get; set; }

        //Проверяем уровень сытости курочек
        //Если он <= 0, то курочки погибают
        protected virtual void CheckSatietyAnimals()
        {

        }
    }
}