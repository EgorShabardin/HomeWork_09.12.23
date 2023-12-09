using System;

namespace Решение_задач
{
    /// <summary>
    /// Класс для теста Рефлексии.
    /// </summary>
    public class ReflectionTest
    {
        static void main()
        {
            Console.WriteLine(Output());
            Console.WriteLine(AddInts(1, 2));
        }
        public static string Output()
        {
            return "Test-Output";
        }
        public static int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}
