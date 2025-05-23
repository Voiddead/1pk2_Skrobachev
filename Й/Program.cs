using System;

class Calculator
{
    private static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                     КАЛЬКУЛЯТОР                           ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
    }

    private static void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nДоступные операции:");
        Console.WriteLine("+ : Сложение");
        Console.WriteLine("- : Вычитание");
        Console.WriteLine("* : Умножение");
        Console.WriteLine("/ : Деление");
        Console.WriteLine("% : Остаток от деления");
        Console.WriteLine("^ : Возведение в степень");
        Console.WriteLine("√ : Квадратный корень");
        Console.WriteLine("! : Факториал");
        Console.ResetColor();
    }

    private static void PrintResult(string operation, double result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║ Результат: {operation} = {result,-20} ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
    }

    private static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nОшибка: {message}");
        Console.ResetColor();
    }

    private static void PrintContinuePrompt()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nХотите продолжить? (д/н)");
        Console.ResetColor();
    }

    private static double CalculateFactorial(int n)
    {
        if (n < 0) throw new ArgumentException("Факториал не определен для отрицательных чисел");
        if (n > 170) throw new ArgumentException("Слишком большое число для вычисления факториала");

        double result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    static void Main(string[] args)
    {
        double num1 = 0, num2 = 0, result;
        char operation;

        Console.Clear();
        PrintHeader();

        while (true)
        {
            PrintMenu();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nВведите операцию:");
            operation = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (operation == '√' || operation == '!')
            {
                Console.WriteLine("\nВведите число:");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    PrintError("Введите корректное число");
                }
            }
            else if (operation != 'q')
            {
                Console.WriteLine("\nВведите первое число:");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    PrintError("Введите корректное число");
                }

                Console.WriteLine("\nВведите второе число:");
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    PrintError("Введите корректное число");
                }
            }

            try
            {
                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        PrintResult($"{num1} + {num2}", result);
                        break;
                    case '-':
                        result = num1 - num2;
                        PrintResult($"{num1} - {num2}", result);
                        break;
                    case '*':
                        result = num1 * num2;
                        PrintResult($"{num1} * {num2}", result);
                        break;
                    case '/':
                        if (num2 == 0)
                            throw new DivideByZeroException();
                        result = num1 / num2;
                        PrintResult($"{num1} / {num2}", result);
                        break;
                    case '%':
                        if (num2 == 0)
                            throw new DivideByZeroException();
                        result = num1 % num2;
                        PrintResult($"{num1} % {num2}", result);
                        break;
                    case '^':
                        result = Math.Pow(num1, num2);
                        PrintResult($"{num1} ^ {num2}", result);
                        break;
                    case '√':
                        if (num1 < 0)
                            throw new ArgumentException("Нельзя извлечь корень из отрицательного числа");
                        result = Math.Sqrt(num1);
                        PrintResult($"√{num1}", result);
                        break;
                    case '!':
                        result = CalculateFactorial((int)num1);
                        PrintResult($"{num1}!", result);
                        break;
                    case 'q':
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nСпасибо за использование калькулятора!");
                        Console.ResetColor();
                        return;
                    default:
                        PrintError("Неверная операция! Выберите одну из доступных операций.");
                        continue;
                }
            }
            catch (DivideByZeroException)
            {
                PrintError("Деление на ноль невозможно!");
                continue;
            }
            catch (ArgumentException ex)
            {
                PrintError(ex.Message);
                continue;
            }
            catch (Exception)
            {
                PrintError("Произошла ошибка при вычислении");
                continue;
            }

            PrintContinuePrompt();
            if (Console.ReadKey().KeyChar.ToString().ToLower() != "д")
                break;

            Console.Clear();
            PrintHeader();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nСпасибо за использование калькулятора!");
        Console.ResetColor();
    }
}
