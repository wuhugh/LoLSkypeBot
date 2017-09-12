using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

public class SkypeMessageFormatter
{
    private static StringBuilder formatter = new StringBuilder();
    private static string finalMessage;

    public static string getRankText(string name, List<LeaguePosition> rankedQueues)
    {
        formatter.AppendFormat("**{0}**\n\n", name);

        // If there are no results, then the player has not placed
        if (!rankedQueues.Any())
        {
            formatter.AppendLine("  UNRANKED");
        }
        else
        {
            foreach (LeaguePosition l in rankedQueues)
            {
                formatter.AppendFormat("  {0}: {1} {2} {3}LP\n", ProgramConstants.rankedQueueNames[l.queueType], l.tier, l.rank, l.leaguePoints).AppendLine();
            }
        }

        finalMessage = formatter.ToString();
        formatter.Clear();
        return finalMessage;
    }

    public static string getLastGameText(string name, Participant player, Match match)
    {
        string win = "Victory";
        if (!player.stats.win)
            win = "Defeat";

        formatter.AppendFormat("**{0}** \n\n {1} - {2}\n\n ", name, ProgramConstants.queueModeCodes[match.queueId], win);
        //formatter.AppendFormat("{0} - {1}\n\n", champ.name, champ.title);
        formatter.AppendFormat("  Kills: {0}  Deaths: {1}  Assists: {2}", player.stats.kills, player.stats.deaths, player.stats.assists);

        finalMessage = formatter.ToString();
        formatter.Clear();
        return finalMessage;
    }

}
