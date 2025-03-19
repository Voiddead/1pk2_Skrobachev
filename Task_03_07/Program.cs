using System;

class Program
{
    static void Main(string[] args)
    {
        double g = 9.8; // ускорение свободного падения, м/с^2
        double t = 0.0; // время, с
        double dt = 0.5; // шаг времени, с

        Console.WriteLine("t\tv");
        Console.WriteLine("-" + new string('-', 13));

        while (t <= 10.0)
        {
            double v = g * t;
            Console.WriteLine($"{t:F1}\t{v:F1}");
            t += dt;
        }
    }
}
