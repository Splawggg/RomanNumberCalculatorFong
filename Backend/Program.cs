using RomanNumberServer;
using RomanNumberServer.Roman;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRomanNumerals, RomanNumerals>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/isValid", (string roman, IRomanNumerals romanNumerals) =>
{
    try
    {
        romanNumerals.ConvertFromRomanLiteral(roman);
        return Results.Ok(true);
    }
    catch (ArgumentException)
    {
        return Results.Ok(false);
    }
});

app.MapGet("/parse", (int number, IRomanNumerals romanNumerals) =>
{
    try
    {
        return Results.Ok(
            romanNumerals.ConvertToRomanLiteral(number));
    }
    catch (ArgumentOutOfRangeException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/add", (string a, string b, IRomanNumerals romanNumerals) =>
{
    try
    {
        return Results.Ok(romanNumerals.Add(a, b));
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/sub", (string a, string b, IRomanNumerals romanNumerals) =>
{
    try
    {
        return Results.Ok(romanNumerals.Sub(a, b));
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/mul", (string a, string b, IRomanNumerals romanNumerals) =>
{
    try
    {
        return Results.Ok(romanNumerals.Mul(a, b));
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/div", (string dividend, string divisor, IRomanNumerals romanNumerals) =>
{
    try
    {
        var (quotient, remainder) =
            romanNumerals.Div(dividend, divisor);

        return Results.Ok(new
        {
            quotient,
            remainder
        });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (DivideByZeroException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();