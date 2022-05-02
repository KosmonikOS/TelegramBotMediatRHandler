using BotTestApp.BotCommandHandlers.Attributes;
using BotTestApp.Services.Interfaces;
using System.Reflection;
using Telegram.Bot.Types;

namespace BotTestApp.Services
{
    public class BotRouter : IBotCommandCreator
    {
        public object CreateCommand(Message message)
        {
            try
            {
                var requestParts = message.Text.Split(" ");
                if (requestParts.Length >= 1)
                {
                    var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(x =>
                        Attribute.IsDefined(x, typeof(BotCommandHandlerAttribute))
                                && x.GetCustomAttribute<BotCommandHandlerAttribute>().CommandName == requestParts[0]);
                    dynamic handler = Activator.CreateInstance(type);
                    var command = handler.HandleCommand(requestParts);
                    return command;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
