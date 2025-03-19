using System;

class Program
{
    static void Main(string[] args)
    {
        // Входные данные
        double x = 100; // Начальный вклад
        double p = 10; // Процент увеличения ежегодно
        double y = 200; // Целевой вклад

        int years = 0;
        while (x < y)
        {
            x += x * (p / 100); // Увеличиваем вклад на p%
            x = Math.Truncate(x); // Отбрасываем дробную часть копеек
            years++;
        }

        Console.WriteLine($"Через {years} лет вклад составит не менее {y} рублей.");
    }
}
