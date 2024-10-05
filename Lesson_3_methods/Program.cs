using System.Threading.Channels;

namespace Lesson_3_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[7];
            int count = 0;    //счетчик кол-ва записи чисел в массив
            int warn = 0;     //счетчик кол-ва ошибок пользователя

            Console.WriteLine("Последовательно введите числа:");
            while (true)
            {
                string? input = Console.ReadLine();
                if (CheckInput(input, warn) == "C")
                {
                    RecordArr(ref arr, input, count);
                    count++;
                }
                else if (CheckInput(input, warn) == "Q")
                    // Вызываем локальную функцию PrintMenu,
                    // если пользователь выберет Очистить, то необходимо обнулить count (функция вернет 0)
                    count = PrintMenu(ref arr, count, warn);  
                    
                else
                {
                    Console.WriteLine(CheckInput(input, warn));
                    warn++;

                }

                //Выполняем проверку введенных данных
                static string CheckInput(string chInput, int countErr)
                {
                    //Если введено число, то возвращаем С
                    if (int.TryParse(chInput, out int number))
                        return "C";
                    //Если введенно q/Q, то возвращаем Q
                    else if (chInput.ToLower() == "q" || chInput.ToUpper() == "q")
                        return "Q";
                    //Если введенна буква отличная от q/Q, то возвращаем текст
                    else
                        return "Введены некорректные данные. Повторите попытку";
                }

                //Записываем введеное число в массив.
                //Если кол-во введенных чисел равно длине массива, то массив расширяем
                static void RecordArr(ref int[] arrIn, string inputIn, int countIn)
                {
                    if (countIn == arrIn.Length)
                        Array.Resize(ref arrIn, arrIn.Length * 2); //расширяем массив                     

                    bool a = int.TryParse(inputIn, out int number);
                    arrIn[countIn] = number;
                }

                //Выводим меню
                static int PrintMenu(ref int[] arrInPrint, int countInPrint, int warnInPtint)
                {
                    Console.WriteLine("****************************");
                    Console.WriteLine($"Итоговые данные:");
                    for (int j = 0; j <= countInPrint - 1; j++)
                        Console.WriteLine($"{arrInPrint[j]} ");
                    Console.WriteLine("****************************");
                    Console.WriteLine($"Для дальнейшей работы выберите один из пунктов меню:\nОчистить-1 \nПродолжить-2\nВыйти-3");
                    string? inputNum = Console.ReadLine();
                    if (int.TryParse(inputNum, out int choiseN))
                    {
                        //Если выбрали Очистить,
                        if (inputNum == "1")
                        {
                            //то очистим массив
                            Array.Clear(arrInPrint, 0, arrInPrint.Length);
                            Console.WriteLine("Массив очищен. Начните ввод чисел заново:");
                            return 0;
                        }

                        //Если выбрали Продолжить,
                        if (inputNum == "2")
                        {
                            Console.WriteLine("Продолжите вводить числа:");
                            return countInPrint;
                        }

                        //Если выбрали Выйти,
                        if (inputNum == "3")
                        {
                            Console.WriteLine("****************************");
                            Console.WriteLine($"Итоговые данные:");
                            for (int k = 0; k <= countInPrint - 1; k++)
                                Console.WriteLine($"{arrInPrint[k]} ");
                            Console.WriteLine($"Кол-во ошибок ввода = {warnInPtint}");
                        }
                        return 0;
                    }
                    return 0;
                }
            }
        }
    }
}