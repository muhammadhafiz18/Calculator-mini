public class HistoryItem
{
    public int Id { get; set; }
    public int Number1 { get; set; }
    public string? Op { get; set; }
    public int Number2 { get; set; }
    public string? Result { get; set; } 
    public DateTime CreatedAt { get; set; }

    public override string ToString()
        => $"{Result!} | {CreatedAt!}";
}