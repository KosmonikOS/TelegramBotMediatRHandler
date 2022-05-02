namespace BotTestApp.BotCommandHandlers.Attributes
{
    public class BotCommandHandlerAttribute : Attribute
    {
        public BotCommandHandlerAttribute(string commandName)
        {
            CommandName = commandName;
        }
        public string CommandName { get; }
    }
}
