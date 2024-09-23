namespace Exs_1_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Введите Ваше Имя");
                string? firstName = Console.ReadLine();

                Console.WriteLine("Введите Вашу Фамилию");
                string? lastName = Console.ReadLine();

                Console.WriteLine("Введите Ваше Отчество");
                string? patrName = Console.ReadLine();

                Console.Write($"{firstName} {lastName} {patrName}");
                Console.ReadKey();
            }
        }
    }
}