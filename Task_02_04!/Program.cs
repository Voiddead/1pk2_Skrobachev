using System;

class Program
{
    static void Main()
    {
        try
        {
            // Запрос данных у пользователя
            Console.WriteLine("Введите год рождения:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите месяц рождения:");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите день рождения:");
            int day = int.Parse(Console.ReadLine());

            // Создание объекта DateTime для даты рождения
            DateTime birthDate = new DateTime(year, month, day);

            // Получение текущей даты
            DateTime currentDate = DateTime.Now;

            // Вычисление возраста пользователя
            int age = currentDate.Year - birthDate.Year;

            // Корректировка возраста, если день рождения еще не наступил в текущем году
            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            // Проверка на совершеннолетие
            if (age >= 18)
            {
                Console.WriteLine("Пользователь совершеннолетний.");
            }
            else
            {
                Console.WriteLine("Пользователь несовершеннолетний.");
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Ошибка: Введена некорректная дата.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введены некорректные данные. Пожалуйста, введите числа.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
