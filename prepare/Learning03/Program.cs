using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new Fraction(); // 1/1
        Fraction frac2 = new Fraction(5); // 5/1
        Fraction frac3 = new Fraction(3, 4); // 3/4
        Fraction frac4 = new Fraction(1, 3); // 1/3

        Console.WriteLine($"Fraction 1: {frac1.GetFractionString()}, Decimal: {frac1.GetDecimalValue()}");
        Console.WriteLine($"Fraction 2: {frac2.GetFractionString()}, Decimal: {frac2.GetDecimalValue()}");
        Console.WriteLine($"Fraction 3: {frac3.GetFractionString()}, Decimal: {frac3.GetDecimalValue()}");
        Console.WriteLine($"Fraction 4: {frac4.GetFractionString()}, Decimal: {frac4.GetDecimalValue()}");

        frac1.SetNumerator(6);
        frac1.SetDenominator(7);

        Console.WriteLine($"Updated Fraction 1: {frac1.GetFractionString()}, Decimal: {frac1.GetDecimalValue()}");
    }
}