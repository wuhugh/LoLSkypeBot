public class LeaguePosition
{
    public string queueType { get; set; } // 3v3, 5v5 Solo, 5v5 Flex
    public int wins { get; set; }
    public int losses { get; set; }
    public bool veteran { get; set; }
    public string playerOrTeamId { get; set; }
    public string playerOrTeamName { get; set; }
    public string tier { get; set; } // BRONZE - CHALLENGER
    public string rank { get; set; } // I - V
    public int leaguePoints { get; set; } // LP

    // Not used for now
    // public bool freshBlood { get; set; }
    // public bool inactive { get; set; }
    // public bool hotStreak { get; set; }
    // public string leagueName { get; set; }

}
