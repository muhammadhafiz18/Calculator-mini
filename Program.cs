﻿using Calculator.Services;

DisplayService.Print("Welcome to Calculator!\nAvailabe commands: calculate, history, clear, exit, cls");

List<HistoryItem> history = [];
HistoryService.LoadHistory("history.json", history);

while (true)
{
    var input = DisplayService.ReadInput("Enter first number (or 'exit')");

    if (input == "exit")
        break;

    else if (input == "cls")
        Console.Clear();

    else if (input == "history") 
        HistoryService.ShowHistory(history);

    else if (input == "clear")
        HistoryService.ClearHistory(history);
        
    else if (input == "calculate")
         PerformService.Calculate(history);

    else
        Console.WriteLine("This command is not available");
}
Console.WriteLine("Good bye");