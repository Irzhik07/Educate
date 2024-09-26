namespace Lesson_2_Arifm_mean
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            
            try
            {
                Console.WriteLine("Введите последовательно пять чисел:");
                numbers[0] = int.Parse(Console.ReadLine());
                numbers[1] = int.Parse(Console.ReadLine());
                numbers[2] = int.Parse(Console.ReadLine());
                numbers[3] = int.Parse(Console.ReadLine());
                numbers[4] = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine($"Ошибка: введены некорретные данные \nВыполните повторный ввод данных");
            }
            finally
            {
                double arifm = (numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4]) / 5.0;
                Console.WriteLine($"Среднее арифметическое введенных чисел = {arifm}");;
            }
        }
    }
}