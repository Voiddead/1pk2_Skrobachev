using System;

class User
{
    // Статическое свойство для хранения текущего пользователя
    public static User CurrentUser { get; private set; }

    // Свойства пользователя
    public string Name { get; }
    public int Age { get; }

    // Конструктор для создания пользователя
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Статический метод для установки текущего пользователя
    public static void SetCurrentUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "Пользователь не может быть null.");
        }
        CurrentUser = user;
    }

    // Переопределение метода ToString для удобного вывода информации о пользователе
    public override string ToString()
    {
        return $"Имя: {Name}, Возраст: {Age}";
    }
}

class Program
{
    static void Main()
    {
        // Создаем пользователей
        User user1 = new User("Иван", 25);
        User user2 = new User("Мария", 30);

        // Устанавливаем текущего пользователя
        User.SetCurrentUser(user1);
        Console.WriteLine("Текущий пользователь: " + User.CurrentUser);

        // Меняем текущего пользователя
        User.SetCurrentUser(user2);
        Console.WriteLine("Текущий пользователь: " + User.CurrentUser);

        // Попытка установить null (вызовет исключение)
        try
        {
            User.SetCurrentUser(null);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
