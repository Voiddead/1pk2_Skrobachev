using System;

class Program
{
    static void Main()
    {
        // Ввод диапазона и шага
        Console.Write("Введите начальную температуру в градусах Цельсия: ");
        double start = double.Parse(Console.ReadLine());

        Console.Write("Введите конечную температуру в градусах Цельсия: ");
        double end = double.Parse(Console.ReadLine());

        Console.Write("Введите шаг изменения температуры: ");
        double step = double.Parse(Console.ReadLine());

        // Вывод заголовка таблицы
        Console.WriteLine("°C\t°F");
        Console.WriteLine("------------");

        // Вывод таблицы
        for (double celsius = start; celsius <= end; celsius += step)
        {
            double fahrenheit = celsius * 1.8 + 32; // Формула перевода
            Console.WriteLine($"{celsius}\t{fahrenheit}");
        }
    }
}
