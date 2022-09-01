namespace Test;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public decimal Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException($"Cannot divide {a} by {b}");
        }

        return (decimal)a / b;
    }

    public int SubtractOrAdd(int a, int b)
        => b > a ? a - b : a + b;

    public int AddXTimes(int a, int b, int count)
    {
        if (count <= 0)
        {
            throw new ArgumentException($"{nameof(count)} must be 1 or higher");
        }

        for (var i = 0; i < count; i++)
        {
            a += b;
        }

        return a;
    }

    public int DoSomething(int a, int b)
    {
        if (a == 1)
        {
            return b;
        }

        if (b == 0) 
        {
            return a;
        }

        return a + b;
    }
}
