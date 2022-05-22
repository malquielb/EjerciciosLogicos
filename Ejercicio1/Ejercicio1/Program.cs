var runnig = true;

while (runnig) {
    try
    {
        Console.WriteLine("Enter an integer value: ");
        var input = Console.ReadLine();

        if (input == null)
            throw new Exception("Invalid input.");

        var arrayLength = int.Parse(input);

        if (arrayLength < 0)
            throw new Exception("Must enter a positive value.");

        var randomInts = new int[arrayLength];
        var randomGenerator = new Random();

        for (int i = 0; i < randomInts.Length; i++)
            randomInts[i] = randomGenerator.Next(1, 11); // random integers in the interval 1-10

        var total = checked(randomInts.Aggregate((a, b) => a * b));

        var result = ComputeResult(total);

        Console.WriteLine("Array: [{0}]", String.Join(",", randomInts.Select(i => i.ToString())));
        Console.WriteLine("Total: {0}", total);
        Console.WriteLine("Result: {0}", result);

        Exit();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


int ComputeResult(int total)
{
    if (total % 2 == 0)
        return total;

    return 0;
}

void Exit()
{
    Start:
    {
        Console.Write("Exit (y/n): ");
        var response = Console.ReadLine();

        if (response == null)
            throw new Exception("Invalid input.");

        switch (response)
        {
            case "y":
                runnig = false;
                break;
            case "n":
                break;
            default:
                Console.WriteLine("{0} keyword is not valid.", response);
                goto Start;
        }
    }
}
