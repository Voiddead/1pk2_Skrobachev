using System;

class Program
{
    static void Main()
    {
        // Пример использования метода Factorial
        Console.WriteLine("Факториал 5: " + Factorial(5)); // 120
        Console.WriteLine("Факториал 0: " + Factorial(0)); // 1
        Console.WriteLine("Факториал 10: " + Factorial(10)); // 3628800

        // Проверка на отрицательное число
        try
        {
            Console.WriteLine("Факториал -3: " + Factorial(-3));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); // Факториал определен только для неотрицательных чисел.
        }
    }

    /// <summary>
    /// Вычисляет факториал для неотрицательного целого числа.
    /// </summary>
    /// <param name="n">Неотрицательное целое число.</param>
    /// <returns>Факториал числа n.</returns>
    /// <exception cref="ArgumentException">Выбрасывается, если n отрицательное.</exception>
    public static long Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Факториал определен только для неотрицательных чисел.");
        }

        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
