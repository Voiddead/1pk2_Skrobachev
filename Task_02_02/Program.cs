using System;

class Program
{
    static void Main()
    {
        // Заданные значения переменных
        double a = 8;
        double b = 14;
        double c = Math.PI / 4; // c = π/4

        // Вычисление значения выражения
        double expressionValue = (4 / b) + (3 / a) - 1;
        double sinC = Math.Sin(c);
        double tgC = Math.Tan(c);
        double denominator = Math.Abs(a - b) * (sinC + tgC);

        // Итоговое значение
        double result = expressionValue / denominator;

        // Вывод результата
        Console.WriteLine("Результат: " + result);
    }
}
