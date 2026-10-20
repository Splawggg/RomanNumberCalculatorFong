/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: RomanNumerals
*--------------------------------------------------------------
*/

using System.Text;

namespace RomanNumberServer.Roman;

public class RomanNumerals : IRomanNumerals
{
    private static readonly (int Value, string Symbol)[] RomanSymbols =
    {
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    };

    public int ConvertFromRomanLiteral(string roman)
    {
        if (string.IsNullOrEmpty(roman))
        {
            throw new ArgumentException("Roman Number is empty.", nameof(roman));
        }

        int result = 0;
        int i = 0;

        while (i < roman.Length)
        {
            int current = GetValue(roman[i]);

            if (i + 1 < roman.Length)
            {
                int next = GetValue(roman[i + 1]);
                if (current < next)
                {
                    result += next - current;
                    i += 2;
                    continue;
                }
            }

            result += current;
            i++;
        }
        if (result < 1 || result > 3999 ||
            ConvertToRomanLiteral(result) != roman)
        {
            throw new ArgumentException("Invalid Roman Number.", nameof(roman));
        }
        return result;
    }

    public string ConvertToRomanLiteral(int number)
    {
        if (number < 1 || number > 3999)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number has to be between 1 and 3999.");
        }

        StringBuilder result = new StringBuilder();

        foreach (var (value, symbol) in RomanSymbols)
        {
            while (number >= value)
            {
                result.Append(symbol);
                number -= value;
            }
        }

        return result.ToString();
    }

    private static int GetValue(char symbol)
    {
        return symbol switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new ArgumentException($"Invalid Roman Sign: {symbol}")
        };
    }

    public bool IsValid(string roman)
    {
        try
        {
            ConvertFromRomanLiteral(roman);
            return true;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
    public string Add(string a, string b)
    {
        int result =
            ConvertFromRomanLiteral(a) +
            ConvertFromRomanLiteral(b);

        return ConvertToRomanLiteral(result);
    }

    public string Sub(string a, string b)
    {
        int result =
            ConvertFromRomanLiteral(a) -
            ConvertFromRomanLiteral(b);

        return ConvertToRomanLiteral(result);
    }

    public string Mul(string a, string b)
    {
        int result =
            ConvertFromRomanLiteral(a) *
            ConvertFromRomanLiteral(b);

        return ConvertToRomanLiteral(result);
    }

    public (string Quotient, string Remainder) Div(
        string dividend,
        string divisor)
    {
        int a = ConvertFromRomanLiteral(dividend);
        int b = ConvertFromRomanLiteral(divisor);

        if (b == 0)
        {
            throw new DivideByZeroException(
                "Division durch null ist nicht möglich.");
        }

        int quotient = a / b;
        int remainder = a % b;

        return (
            quotient == 0 ? "N" : ConvertToRomanLiteral(quotient),
            remainder == 0 ? "N" : ConvertToRomanLiteral(remainder)
        );
    }
}