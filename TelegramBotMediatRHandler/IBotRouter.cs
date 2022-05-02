using Telegram.Bot.Types;

namespace BotTestApp.Services.Interfaces
{
    public interface IBotCommandCreator
    {
        public object CreateCommand(Message message);
    }
}
