public class FractionalNumber
{
    private int sign;
    private int dividend;
    private int divider;

    public int Sign
    {
        get { return sign; }
        set
        {
            if (value == 1 || value == -1)
                sign = value;
            else
                throw new ArgumentException("Sign must be 1 or -1.");
        }
    }

    public int Dividend
    {
        get { return dividend; }
        set
        {
            if (value >= 0)
                dividend = value;
            else
                throw new ArgumentException("Dividend must be a non-negative integer.");
        }
    }

    public int Divider
    {
        get { return divider; }
        set
        {
            if (value > 0)
                divider = value;
            else
                throw new ArgumentException("Divider must be a positive integer.");
        }
    }

    public string GetNumber()
    {
        return $"{(sign == -1 ? "-" : "+")}{dividend}/{divider}";
    }

    public static void Main()
    {
        FractionalNumber fraction = new FractionalNumber
        {
            Sign = 1,
            Dividend = 5,
            Divider = 7
        };

        string fractionalNumber = fraction.GetNumber();
        Console.WriteLine($"Fractional Number: {fractionalNumber}"); // Вывод: Fractional Number: +5/7

        try
        {
            FractionalNumber invalidFraction = new FractionalNumber
            {
                Sign = 0,
                Dividend = -10,
                Divider = 0
            };
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); // Выведет сообщения об ошибках
        }
    }
}
