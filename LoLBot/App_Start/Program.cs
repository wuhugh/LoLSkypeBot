using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Linq;


// Tertium
// sid: 19451869
// aid: 32145753

class Program
{
    // TODO: Find a better way to include the game constants
    const string riotAPIKey = ProgramConstants.riotAPIKey;
    static Dictionary<string, string> regions = ProgramConstants.regions;
    static Dictionary<string, string> queueNames = ProgramConstants.rankedQueueNames;
    static Dictionary<int, string> queueMode = ProgramConstants.queueModeCodes;
    

    static string endpoint;
    static string uri;

   
    public static string createRankedMessage(string name)
    {
        Summoner summoner = getSummoner(name);
        return SkypeMessageFormatter.getRankText(name, getCurrentRanks(summoner));
    }

    public static string createLastGameMessage(string name)
    {
        Summoner summoner = getSummoner(name);
        long lastGameId = getLastGameId(summoner);
        Match match = getMatchForAccount(lastGameId, summoner);

        Participant player = getParticipantForGame(summoner, match);
        //ChampionBasic champ = getBasicChampionInfo(player.championId);

        return SkypeMessageFormatter.getLastGameText(name, player, match);
    }

 
    // Returns an instance of a summoner given their name
    private static Summoner getSummoner(string name)
    {
        // Create the URI to retrieve the summoner ID
        endpoint = $"/lol/summoner/v3/summoners/by-name/{name}";
        uri = $"{regions["NA"]}{endpoint}?{riotAPIKey}";

        // Deserialize the JSON response to access the fields
        Summoner summoner = JsonConvert.DeserializeObject<Summoner>(apiCall(uri));
        return summoner;
    }


    // Returns a list of ranked information for each queue mode
    private static List<LeaguePosition> getCurrentRanks(Summoner summoner)
    {
        endpoint = $"/lol/league/v3/positions/by-summoner/{summoner.id}";
        uri = $"{regions["NA"]}{endpoint}?{riotAPIKey}";

        // The result is returned in an array, with each element being a Json object containing
        // ranked information for each 
        List<LeaguePosition> rankedQueues = JsonConvert.DeserializeObject<List<LeaguePosition>>(apiCall(uri));

        return rankedQueues;
    }

    
    // Returns a list of 20 of the latest games
    private static Matchlist getRecentMatchlist(Summoner summoner)
    {
        endpoint = $"/lol/match/v3/matchlists/by-account/{summoner.accountId}/recent";
        uri = $"{regions["NA"]}{endpoint}?{riotAPIKey}";

        Matchlist matchList = JsonConvert.DeserializeObject<Matchlist>(apiCall(uri));
        return matchList;
    }


    // Returns a list of only the gameIds of the last 20 games
    private static List<long> getRecentListOfGameIds(Summoner summoner)
    {
        Matchlist matchList = getRecentMatchlist(summoner);
        List<long> recentGameIdList = new List<long>();

        foreach (MatchReference m in matchList.matches)
        {
            recentGameIdList.Add(m.gameId);
        }

        return recentGameIdList;
    }


    // Returns information about a match
    private static Match getMatch(long gameId)
    {
        endpoint = $"/lol/match/v3/matches/{gameId}";
        uri = $"{regions["NA"]}{endpoint}?{riotAPIKey}";

        Match match = JsonConvert.DeserializeObject<Match>(apiCall(uri));
        return match;
    }

    // Returns information about a match and gives the participantID for the summoner given
    private static Match getMatchForAccount(long gameId, Summoner summoner)
    {
        endpoint = $"/lol/match/v3/matches/{gameId}?forAccountId={summoner.accountId}";
        uri = $"{regions["NA"]}{endpoint}&{riotAPIKey}";

        Match match = JsonConvert.DeserializeObject<Match>(apiCall(uri));
        return match;
    }


    // Returns the gameId of the last summoner 
    private static long getLastGameId(Summoner summoner)
    {
        Matchlist matchList = getRecentMatchlist(summoner);
        return matchList.matches.First().gameId;
    }


    // Returns the ID needed to identify a player in a match
    private static int getParticipantId(Summoner summoner, Match match)
    {
        int myParticipantId = -1;

        foreach (ParticipantIdentity p in match.participantIdentities)
        {
            if (p.player != null)
            {
                myParticipantId = p.participantId;
                break;
            }
        }

        return myParticipantId;
    }
  

    // Returns the information about the player in a certain match
    private static Participant getParticipantForGame(Summoner summoner, Match match)
    {
        int myParticipantId = getParticipantId(summoner, match);

        foreach(Participant p in match.participants)
        {
            if (p.participantId == myParticipantId)
                return p;
        }

        return null;
    }


    /*
    private static ChampionBasic getBasicChampionInfo(int champId)
    {
        endpoint = $"/lol/static-data/v3/champions/{champId}";
        uri = $"{regions["NA"]}{endpoint}?{riotAPIKey}";

        ChampionBasic champ = JsonConvert.DeserializeObject<ChampionBasic>(apiCall(uri));
        return champ;
    }
    */

    private static string apiCall(string uri)
    { 
        WebRequest request = WebRequest.Create(uri);
        WebResponse response = request.GetResponse();

        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);

        string responseFromServer = reader.ReadToEnd();

        reader.Close();
        responseStream.Close();

        return responseFromServer;
    }

   
}

