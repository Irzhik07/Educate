namespace Lesson_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[7];
            char ch = 'Q';    //символ выхода в меню
            int count = 0;    //счетчик кол-ва записи чисел в массив
            int warn = 0;     //счетчик кол-ва ошибок пользователя

            do
            {
                Console.WriteLine("Последовательно введите числа:");
                // пробегаемся по элементам массива
                for (int i = 0; i <= arr.Length; i++)
                {
                    //Если массив переполнен,
                    if (arr.Length >= i)
                    {
                        //то расширяем его
                        Array.Resize(ref arr, i + 10);
                    }

                    string? input = Console.ReadLine();

                    if (!input.StartsWith(ch.ToString()) && !int.TryParse(input, out int number))
                    {
                        Console.WriteLine("Введены некорректные данные");
                        i--;
                        warn++;
                        continue;
                    }
                    else
                    {
                        try
                        {
                            //Если введено число, запишем его в массив
                            if (int.TryParse(input, out int numbers))
                            {
                                arr[i] = numbers;
                                count++;
                            }
                            // Если введен символ Q, то выведем данные из массива и меню
                            if (input.StartsWith(ch.ToString()))
                            {
                                Console.WriteLine("****************************");
                                Console.WriteLine($"Итоговые данные:");
                                for (int j = 0; j <= count - 1; j++)
                                {
                                    Console.WriteLine($"{arr[j]} ");
                                }
                                Console.WriteLine("****************************");
                                Console.WriteLine($"Для дальнейшей работы выберите один из пунктов меню:\nОчистить-1 \nПродолжить-2\nВыйти-3");
                                string? inputNum = Console.ReadLine();
                                if (int.TryParse(inputNum, out int choiseN))
                                {
                                    //Если пользователяь выбрал Очистить,
                                    if (inputNum == "1")
                                    {
                                        //то очистим массив
                                        Array.Clear(arr, 0, arr.Length);
                                        break;
                                    }
                                    if (inputNum == "2")
                                    {
                                        continue;
                                    }
                                    if (inputNum == "3")
                                    {
                                        Console.WriteLine("****************************");
                                        Console.WriteLine($"Итоговые данные:");
                                        for (int k = 0; k <= count - 1; k++)
                                        {
                                            Console.WriteLine($"{arr[k]} ");
                                        }
                                        Console.WriteLine($"Кол-во ошибок ввода: {warn}");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Введены некорректные данные");
                                        warn++;
                                        i--;
                                        continue;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Непредвиденная ошибка. Повторите попытку снова");
                            break;
                        }
                    }
                }
            }
            while (true);
        }
    }
}