namespace Calculator.Services;

public static class PerformService
{
    public static void Calculate(int a, List<HistoryItem> history)
    {
        try
        {
            string op = DisplayService.ReadInput("Enter operator (+, -, *, /): ");

            int b = int.Parse(DisplayService.ReadInput("Enter second number: "));
            int result = Perform(a, b, op);

            string stringResult = $"{a} {op} {b} = {result}";

            HistoryItem historyItem = new()
            {
                Id = history.Count + 1,
                Number1 = a,
                Op = op,
                Number2 = b,
                Result = stringResult,
                CreatedAt = DateTime.Now
            };

            history.Add(historyItem); // " 5 + 3 = 8 "
            HistoryService.SaveHistory( history, "history.json");

            DisplayService.Print(stringResult);
        }
        catch (Exception e) 
        { 
            DisplayService.Print($"Error: {e.Message}");
        }
    }

    private static int Perform(int a, int b, string op)
    {
        return op switch
        {
            "+" => Add(a, b),
            "-" => Substract(a, b),
            "*" => Multiply(a, b),
            "/" => Divide(a, b),
            _ => throw new InvalidOperationException("Invalid operator"),
        };
    }

    private static int Add(int a, int b)
        => a + b;

    private static int Substract(int a, int b)
        => a - b;

    private static int Multiply(int a, int b)
        => a * b;

    private static int Divide(int a, int b)
        => a / b;
}