using System;
using System.Collections.Generic;
using System.IO;

public class WordSearcher
{
    public static List<string> SearchWordInFile(string filePath, string searchWord)
    {
        List<string> matchingLines = new List<string>();

        try
        {
            // Читаем файл построчно
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Проверяем, содержит ли строка искомое слово (регистронезависимо)
                    if (line.IndexOf(searchWord, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        matchingLines.Add(line);
                    }
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

        return matchingLines;
    }

    public static void Main(string[] args)
    {
        // Пример использования функции
        string filePath = "path/to/your/file.txt";
        string searchWord = "искомое_слово";

        List<string> result = SearchWordInFile(filePath, searchWord);

        if (result.Count > 0)
        {
            Console.WriteLine("Строки, содержащие искомое слово:");
            foreach (string line in result)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Искомое слово не найдено.");
        }
    }
}
