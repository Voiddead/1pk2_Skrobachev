using System;

class Program
{
    static void Main(string[] args)
    {
        double x = -4;
        double h = 0.5;

        Console.WriteLine("x\t|x|");
        Console.WriteLine("-" + new string('-', 13));

        while (x <= 4)
        {
            double y = Math.Abs(x);
            Console.WriteLine($"{x:F1}\t{y:F1}");
            x += h;
        }
    }
}
