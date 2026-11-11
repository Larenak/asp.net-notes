
public class Note
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Header { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }
}

public class CreateNote
{
    public int UserId { get; set; }
    public string? Header { get; set; }
    public string? Text { get; set; }
}