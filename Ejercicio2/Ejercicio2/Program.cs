using System.Text.RegularExpressions;

var runnig = true;

while (runnig)
{
    try
    {
        Console.Write("Enter your PIN: ");
        var pin = Console.ReadLine();

        if (pin == null)
            throw new Exception("[!!] Invalid input");

        var result = ValidatePin(pin);

        Console.WriteLine(result);

        Exit();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


string ValidatePin(string pin)
{
    var matches = Regex.Matches(pin, @"\d");

    if (matches.Count == 0)
        return "[X] PIN is invalid (has not digits)";

    if (matches.Count != 4 && matches.Count != 6)
        return "[X] PIN is invalid (must have length of 4 or 6)";

    var digits = matches.Select(m => m.Value);

    if (digits.Count() != digits.Distinct().Count())
        return "[X] PIN is invalid (repeated digits)";

    return String.Format("[OK] PIN: {0} is valid", String.Join("", digits));
}

void Exit()
{
    Start:
    {
        Console.Write("Exit (y/n): ");
        var response = Console.ReadLine();

        if (response == null)
            throw new Exception("[!!] Invalid input");

        switch (response)
        {
            case "y":
                runnig = false;
                break;
            case "n":
                break;
            default:
                Console.WriteLine("{0} keyword is not valid", response);
                goto Start;
        }
    }
}

