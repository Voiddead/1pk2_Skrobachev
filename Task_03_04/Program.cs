using System;

class Program
{
    static void Main()
    {
        int lineCount = 0; // Счетчик введенных строк

        while (true)
        {
            Console.Write("Введите текст: ");
            string input = Console.ReadLine();

            // Проверка на завершение ввода
            if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
            {
                break;
            }

            lineCount++; // Увеличиваем счетчик строк
            Console.Clear(); // Очищаем консоль
        }

        // Вывод результата
        Console.WriteLine($"Количество введенных строк: {lineCount}");
    }
}
