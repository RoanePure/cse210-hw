public class JournalEntryDraft
{
    public string Prompt {get; set;}
    public string Response {get; set;}
    public string Date {get; set;}

    public JournalEntryDraft(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date} - {Prompt}\nResponse: {Response\n}";
    }
}