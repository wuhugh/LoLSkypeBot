using System.Collections.Generic;

public class ProgramConstants
{
    // Rito's generated API key
    public const string riotAPIKey = "api_key=RGAPI-b24d2d9d-90cc-4f19-bd2d-dffcfb22f627";

    // Start of the URI for each resource
    // Ex: regions["NA"] returns the endpoint for the NA server
    public static Dictionary<string, string> regions = new Dictionary<string, string>
{
    {"BR", "https://br1.api.riotgames.com" },
    {"EUNE", "https://eun1.api.riotgames.com" },
    {"EUW","https://euw1.api.riotgames.com" },
    {"JP", "https://jp1.api.riotgames.com" },
    {"KR", "https://kr.api.riotgames.com" },
    {"LAN", "https://la1.api.riotgames.com" },
    {"LAS", "https://la2.api.riotgames.com" },
    {"NA", "https://na1.api.riotgames.com" },
    {"OCE", "https://oc1.api.riotgames.com" },
    {"TR", "https://tr1.api.riotgames.com" },
    {"RU", "https://ru.api.riotgames.com" },
    {"PBE", "https://pbe1.api.riotgames.com" }
};

    // Renaming the ranked queue names given by the API
    public static Dictionary<string, string> rankedQueueNames = new Dictionary<string, string>
{
    {"RANKED_SOLO_5x5", "5v5 Solo/Duo" },
    {"RANKED_FLEX_SR", "5v5 Flex" },
    {"RANKED_FLEX_TT", "3v3 Flex" }
};

    // Finding the name of the game mode
    public static Dictionary<int, string> queueModeCodes = new Dictionary<int, string>
{
    {0, "Custom" },
    {8, "Normal 3v3" },
    {2, "Normal 5v5 Blind Pick" },
    {14, "Normal 5v5 Draft Pick" },
    {4, "Ranked 5v5 Solo" },
    {6, "Ranked 5v5 Premade" },
    {9, "Ranked 3v3 Flex" },
    {41, "Ranked 3v3 Team" },
    {16, "Dominion 5v5 Blind Pick" },
    {17, "Dominion 5v5 Draft Pick" },
    {7, "Summoner's Rift Coop vs AI (Old)" },
    {25, "Dominion Coop vs AI" },
    {31, "Summoner's Rift Coop vs AI Intro" },
    {32, "Summoner's Rift Coop vs AI Beginner" },
    {33, "Summoner's Rift Coop vs AI Intermediate" },
    {52, "Twisted Treeline Coop vs AI" },
    {61, "Team Builder" },
    {65, "ARAM" },
    {70, "One for All" },
    {72, "Snowdown Showdown 1v1" },
    {73, "Snowdown Showdown 2v2" },
    {75, "Summoner's Rift Hexakill" },
    {76, "Ultra Rapid Fire" },
    {83, "Ultra Rapid Fire vs AI" },
    {91, "Doom Bots Rank 1" },
    {92, "Doom Bot Rank 2" },
    {93, "Doom Bots Rank 5" },
    {96, "Ascension" },
    {100, "Butcher's Bridge" },
    {300, "Poro King" },
    {310, "Nemesis" },
    {313, "Black Market Brawler's" },
    {315, "Nexus Siege" },
    {317, "Definitely Not Dominion" },
    {318, "All Random URF" },
    {325, "All Random Summoner's Rift" },
    {400, "Normal 5v5 Draft Pick" },
    {410, "Ranked 5v5 Draft Pick" },
    {420, "Ranked 5v5 Solo" },
    {430, "Normal 5v5 Blind Pick" },
    {440, "Ranked 5v5 Flex" },
    {600, "Blood Hunt Assassin" },
    {610, "Dark Star" }
};

    public static string[] validCommands =
    {
        "!rank",
        "!lastgame",
        "!champsummary",
        "!champdetails"
    };
}

