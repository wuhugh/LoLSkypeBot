public class Participant
{
    public int participantId { get; set; }
    public int teamId { get; set; }
    public int championId { get; set; }
    public int spell1Id { get; set; }
    public int spell2Id { get; set; }
    public ParticipantStats stats { get; set; }

    // Not used for now
    // public List<Mastery> masteries { get; set; }
    // public List<Rune> runes { get; set; }
    // public Timeline timeline { get; set; }
    // public string highestAchievedSeasonTier { get; set; }
}