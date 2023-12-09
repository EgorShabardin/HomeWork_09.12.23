using System;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;

namespace Решение_задач
{
    internal class Program
    {
        /// <summary>
        /// Метод, который выводит на экран числа от 1 до 10.
        /// </summary>
        static void DisplayingNumbersOnScreen()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
        }

        /// <summary>
        /// Метод, вычисляющий факториал введенного числа.
        /// </summary>
        /// <param name="number"> Число. </param>
        /// <returns> Возвращает факториал введенного числа. </returns>
        static int FactorialCalculation(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * FactorialCalculation(number - 1);
        }

        /// <summary>
        /// Метод, вычисляющий факториал введенного числа асинхронно.
        /// </summary>
        /// <param name="number"> Число. </param>
        static async Task<int> FactorialCalculationAsync(int number)
        {
            int factorial = await Task.Run(() => FactorialCalculation(number));
            Thread.Sleep(8000);

            return factorial;
        }

        /// <summary>
        /// Метод, вычисляющий квадрат введенного числа.
        /// </summary>
        /// <param name="number"> Число. </param>
        /// <returns> Возвращает квадрат введенного числа. </returns>
        static int CalculatingSquareOfNumber(int number)
        {
            return (number * number);
        }

        static async Task Main()
        {
            bool isTaskEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 77}", "РЕШЕНИЕ ЗАДАЧ. МЕНЮ ЗАДАНИЙ\n");

                Console.WriteLine("Подсказка:\n" +
                                  "Задание №1. Программа создает три потока, каждый из которых выводят числа от 1 до 10                        -   цифра 1\n" +
                                  "Задание №2. Программа асинхронно вычисляет факториал и синхронно вычисляет квадрат числа                    -   цифра 2\n" +
                                  "Задание №3. Программа выводит на экран все методы заданного объекта                                         -   цифра 2\n" +
                                  "Закончить выполнение заданий и выйти из программы                                                           -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Задание №1. Программа создает три потока, каждый из которых выводят числа от 1 до 10.
                        Console.Clear();
                        Console.WriteLine("{0, 104}", "ЗАДАНИЕ №1. ПРОГРАММА СОЗДАЕТ ТРИ ПОТОКА, КАЖДЫЙ ИЗ КОТОРЫХ ВЫВОДЯТ ЧИСЛА ОТ 1 ДО 10\n");

                        Thread firstThread = new Thread(DisplayingNumbersOnScreen);
                        Thread secondThread = new Thread(DisplayingNumbersOnScreen);
                        Thread thirdThread = new Thread(DisplayingNumbersOnScreen);

                        firstThread.Start();
                        secondThread.Start();
                        thirdThread.Start();

                        Thread.Sleep(100);

                        Console.Write("\n\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        // Задание №2. Программа асинхронно вычисляет факториал и синхронно вычисляет квадрат числа.
                        Console.Clear();
                        Console.WriteLine("{0, 105}", "ЗАДАНИЕ №2. ПРОГРАММА АСИНХРОННО ВЫЧИСЛЯЕТ ФАКТОРИАЛ И СИНХРОННО ВЫЧИСЛЯЕТ КВАДРАТ ЧИСЛА\n");

                        int number = 5;

                        int square = CalculatingSquareOfNumber(number);
                        Console.WriteLine($"{number}^2 = {square}");

                        int factorial = await FactorialCalculationAsync(number);         
                        Console.WriteLine($"{number}! = {factorial}");   

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        // Задание №3. Программа выводит на экран все методы заданного объекта.
                        Console.Clear();
                        Console.WriteLine("{0, 94}", "ЗАДАНИЕ №3. ПРОГРАММА ВЫВОДИТ НА ЭКРАН ВЫ МЕТОДЫ ЗАДАННОГО ОБЪЕКТА\n");

                        ReflectionTest reflectionTestObject = new ReflectionTest();

                        Type myType = reflectionTestObject.GetType();
                        MethodInfo[] methods = myType.GetMethods();

                        Console.WriteLine("Методы:");

                        foreach (MethodInfo method in methods)
                        {
                            Console.WriteLine(method.Name);
                        }

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("{0, 71}", "ВЫ ВЫШЛИ ИЗ ПРОГРАММЫ");
                        isTaskEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("{0, 102}", "ТАКОГО ЗАДАНИЯ НЕТ! ДОСТУПНЫЕ ЗАДАНИЯ УКАЗАНЫ В ПОДСКАЗКЕ. ПОВТОРИТЕ ПОПЫТКУ\n");
                        break;
                }
            } while (!isTaskEnd);
        }
    }
}
