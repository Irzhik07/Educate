namespace Calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число:");
            bool z1 = double.TryParse(Console.ReadLine(), out var d1);
            if (z1 == false)
            {
                Console.Write("Неверный формат данных");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Введите второе число:");
                bool z2 = double.TryParse(Console.ReadLine(), out var d2);
                if (z2 == false)
                {
                    Console.Write("Неверный формат данных");
                    Console.ReadKey();
                }
                else
                { 
                    Console.Write("Введите арифметическую операцию (+, -, *, /): ");
                    bool z3 = char.TryParse(Console.ReadLine(), out var c);

                    if (z3 == false)
                    {
                        Console.Write("Неверный формат данных");
                        Console.ReadKey();
                    }
                    else
                    {
                        double result = 0;

                        if (c == '+')
                            result = d1 + d2;
                        if (c == '-')
                            result = d1 - d2;
                        if (c == '*')
                            result = d1 * d2;
                        if (c == '/')
                            result = d1 / d2;
                        Console.WriteLine($"Результат: {d1} {c} {d2} = {result}");
                    }
                }
            }
        }
    }
}