using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Путь к файлу
        string filePath = "example.txt";

        // Запрашиваем у пользователя текст для поиска и замены
        Console.Write("Введите текст для поиска: ");
        string searchText = Console.ReadLine();

        Console.Write("Введите текст для замены: ");
        string replaceText = Console.ReadLine();

        // Вызываем функцию замены текста
        ReplaceTextInFile(filePath, searchText, replaceText);

        Console.WriteLine("Замена текста выполнена успешно.");
    }

    static void ReplaceTextInFile(string filePath, string searchText, string replaceText)
    {
        // Читаем весь текст из файла
        string fileContent = File.ReadAllText(filePath);

        // Заменяем текст
        fileContent = fileContent.Replace(searchText, replaceText);

        // Записываем измененный текст обратно в файл
        File.WriteAllText(filePath, fileContent);
    }
}
