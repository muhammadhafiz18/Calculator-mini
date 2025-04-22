using System.Text.Json;
using System.Xml;

namespace Calculator.Services;

public static class HistoryService
{
    public static void ShowHistory(List<HistoryItem> history)
    {
        if (history.Count == 0)
        {
            DisplayService.Print("History is empty");
            return;
        }
        
        while (true)
        {
            DisplayService.PrintHistory(history);

            var input = DisplayService.ReadInput("Cancel or Filter: ");

            if (input == "cancel")
                return; // bosh menyuga chiqib ketadi
        
            else if (input == "filter")
            {
                FilterHistory(history);
                Console.Clear();
            }

            else
                DisplayService.Print("This command is not available");
        }
    }

    private static void FilterHistory(List<HistoryItem> history)
    {
        while (true)
        {
            var input = DisplayService.ReadInput("Enter operation to filter(+, -, *, /) or cancel: ").ToLower().Trim();
            if (input == "cancel")
                return;
            
            else if (input == "+" || input == "-" || input == "*" || input == "/") 
            {
                var filteredHistory = history.Where(x => x.Op == input).ToList();
                DisplayService.PrintHistory(filteredHistory);
            }

            else
                Console.WriteLine("This command is not available");
        }
    }

    public static void ClearHistory(List<HistoryItem> history)
    {
        if (history.Count == 0)
        {
            DisplayService.Print("nothing to clear");
            return;
        }

        while(true)
        {
            DisplayService.PrintHistory(history);

            Console.WriteLine();

            string input = DisplayService.ReadInput("Enter ID or if you want to clear all, just enter \"all\"");

            if(input == "cancel")
                break;

            else if(int.TryParse(input, out int result))
            {
                if(history.Count < result || result < 0)
                {
                    Console.WriteLine("Index was out of range");
                    continue;
                }
                else
                {
                    history.RemoveAt(result - 1);
                    SaveHistory(history, "history.json");
                    Console.WriteLine($"{result} is removed...");
                    break;
                }  
            }

            else if(input == "all")
            {
                history.Clear();
                SaveHistory(history, "history.json");
                Console.WriteLine($"History totally cleared...");
                break;
            }

            else
            {
                Console.WriteLine("This command is not available");
                continue;
            }
        }
    }

    public static void SaveHistory(List<HistoryItem> history, string path)
    {
        var options = new JsonSerializerOptions
        { 
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string json = JsonSerializer.Serialize(history, options);

        File.WriteAllText(path, json);
    }

    public static void LoadHistory(string path, List<HistoryItem> history)
    {
        if(File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            
            var historyFromFile = JsonSerializer.Deserialize<List<HistoryItem>>(jsonString);

            if(historyFromFile != null)
                history.AddRange(historyFromFile);
        }
    }
}