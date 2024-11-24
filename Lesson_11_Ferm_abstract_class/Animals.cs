using Lesson_11_Ferm_abstract_class;
using static Lesson_11.Program;

namespace Lesson_11
{
    public abstract class Animals
    {
        public string Name { get; set; }
        public bool Live { get; set; }
        public int Satiety { get; protected set; }

        public Animals(string name, bool live = true, int satiety = 2) 
        { 
            Name = name;
            Live = true; 
            Satiety = satiety; 
        }

        public delegate void SatietyChangedEventHandler(string message);
        //Событие изменения уровня сытости животных
        public event SatietyChangedEventHandler? SatietyChanged;

        protected virtual void OnSatietyChanged(string message)
        {
            SatietyChanged?.Invoke(message);
        }

        //Проверяем уровень сытости животных
        internal abstract bool CheckSatietyAnimals();

    }
}