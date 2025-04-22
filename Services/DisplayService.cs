
public static class DisplayService
{
    public static void Print(string message)
        => Console.WriteLine(message);

    public static string ReadInput(string message)
    {
        Print(message);
        return ReadInput();   
    }

    public static string ReadInput()
        => Console.ReadLine()!.Trim().ToLower();

    internal static void PrintHistory(List<HistoryItem> history)
    {
        if (history.Count == 0)
        {
            Print("History is empty");
            return;
        }
        
        for (int i = 0; i < history.Count; i++)
            Print($"({i + 1}). {history[i]}");
    }
}