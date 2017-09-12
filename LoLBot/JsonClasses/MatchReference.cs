public class MatchReference
{
    public long gameId { get; set; }
    public int champion { get; set; }
    public int queue { get; set; }
    public int season { get; set; }
    public long timestamp { get; set; }
    public string role { get; set; }
    public string lane { get; set; }

    // Not used for now
    // public string platformId { get; set; }
}
