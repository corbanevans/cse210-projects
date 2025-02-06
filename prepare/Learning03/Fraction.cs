public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int _top)
    {
        _numerator = _top;
        _denominator = 1;
    }

    public Fraction(int _top, int _bottom)
    {
        _numerator = _top;
        _denominator = _bottom != 0 ? _bottom : 1;
    }

    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int _value)
    {
        _numerator = _value;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int _value)
    {
        if (_value != 0)
        {
            _denominator = _value;
        }
        else
        {
            Console.WriteLine("Denominator cannot be zero.");            
        }
    }



    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}