/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: RomanNumerals
*--------------------------------------------------------------
*/

namespace RomanNumberServer.Roman;

public interface IRomanNumerals
{
    bool IsValid(string roman);

    string ConvertToRomanLiteral(int number);
    int ConvertFromRomanLiteral(string roman);

    string Add(string a, string b);
    string Sub(string a, string b);
    string Mul(string a, string b);

    (string Quotient, string Remainder) Div(string dividend, string divisor);
}