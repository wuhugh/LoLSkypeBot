using System.Collections.Generic;

public class Match
{
    public long gameId { get; set; }
    public long gameCreation { get; set; }
    public int gameDuration { get; set; }
    public int queueId { get; set; }
    public int seasonId { get; set; }
    public List<Participant> participants { get; set; }
    public List<ParticipantIdentity> participantIdentities { get; set; }
    public List<TeamStats> teams { get; set; }

    // Not used for now
    // public string gameVersion { get; set; }
    // public string gameMode { get; set; }
    // public string gameType { get; set; }
    // public int mapId { get; set; }
    // public string platformId { get; set; }

}