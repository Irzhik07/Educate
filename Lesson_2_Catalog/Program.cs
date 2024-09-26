namespace Lesson_2_Catalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] users = new string[2, 3];
            int[] age = new int[3];
            try 
            {
                Console.WriteLine("Введите данные первого пользователя (1)");
                Console.Write("Фамилия:");
                users[0,0] = Console.ReadLine();
                
                if (users[0, 0] == "")
                    throw new ArgumentException("Введены незначащие данные");

                Console.Write("Город:");
                users[1, 0] = Console.ReadLine();
                
                if (users[1, 0] == "")
                    throw new ArgumentException("Введены незначащие данные");

                Console.Write("Возраст:");
                age[0] = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            try
            {
                Console.WriteLine("Введите данные второго пользователя (2)");
                Console.Write("Фамилия:");
                users[0, 1] = Console.ReadLine();

                if (users[0, 1] == "")
                    throw new ArgumentException("Введены незначащие данные");
                    
                Console.Write("Город:");
                users[1, 1] = Console.ReadLine();

                if (users[1, 1] == "")
                    throw new ArgumentException("Введены незначащие данные");

                Console.Write("Возраст:");
                age[1] = int.Parse(Console.ReadLine());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            try
            {
                Console.WriteLine("Введите данные третьего пользователя (3)");
                Console.Write("Фамилия:");
                users[0, 2] = Console.ReadLine();

                if (users[0, 2] == "")
                    throw new ArgumentException("Введены незначащие данные");

                Console.Write("Город:");
                users[1, 2] = Console.ReadLine();

                if (users[1, 2] == "")
                    throw new ArgumentException("Введены незначащие данные");

                Console.Write("Возраст:");
                age[2] = int.Parse(Console.ReadLine());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                Console.WriteLine("Выберите пользователя, по которому требуется вывести информацию: 1,2 или 3");
                string? input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine($"Результат: Фамилия - {users[0, 0]}, Город - {users[1, 0]}, Возраст - {age[0]}");
                }
                else
                {
                    Console.WriteLine(input == "2" ? $"Результат: Фамилия - {users[0, 1]}, Город - {users[1, 1]}, Возраст - {age[1]}" : $"Результат: Фамилия - {users[0, 2]}, Город - {users[1, 2]}, Возраст - {age[2]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}