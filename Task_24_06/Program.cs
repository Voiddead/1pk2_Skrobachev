using System;
using System.IO;

public class FileLineCounter
{
    public static int CountLines(string filePath)
    {
        int lineCount = 0;

        try
        {
            // Используем StreamReader для чтения файла
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Читаем файл построчно и увеличиваем счетчик
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден. Проверьте путь к файлу.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }

        return lineCount;
    }

    public static void Main(string[] args)
    {
        // Пример использования метода
        string filePath = "path/to/your/file.txt";
        int lines = CountLines(filePath);
        Console.WriteLine($"Количество строк в файле: {lines}");
    }
}
