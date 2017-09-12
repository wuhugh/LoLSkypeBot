using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Linq;

namespace LoLBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // Split the message based on white space to determine the intent
            var tokens = activity.Text.Split(' ');

            // Check if the message is in the right format
            // TODO: Clean up this block
            if(tokens.Length >= 2 && ProgramConstants.validCommands.Contains(tokens[1]))
            {
                try
                {
                    // This recreates the summoner's name in case we split it above
                    string name = string.Join(" ", tokens.Skip(2));

                    if (tokens[1] == "!rank")
                        await context.PostAsync(Program.createRankedMessage(name));
                    else if (tokens[1] == "!lastgame")
                        await context.PostAsync(Program.createLastGameMessage(name));
                }
                catch (Exception e)
                {
                    await context.PostAsync($"Exception: {e.GetType().Name} - {e.Message}");
                }
            }

            context.Wait(MessageReceivedAsync);
        }
    }
}