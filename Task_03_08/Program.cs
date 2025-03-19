using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Числа, которые делятся на 3, но не делятся на 5:");

        for (int i = 20; i <= 50; i++)
        {
            if (i % 3 == 0 && i % 5 != 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
