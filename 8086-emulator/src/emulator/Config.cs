namespace Emulator
{
    internal static class Config
    {
        public static readonly string MessagePrefix = "$";
        public static readonly string InputPrefix = ">>";
        public static readonly ConsoleColor MessagePrefixColor = ConsoleColor.DarkCyan;
        public static readonly ConsoleColor InputPrefixColor = ConsoleColor.Gray;
        public static readonly ConsoleColor InputColor = ConsoleColor.Gray;

        public static readonly Dictionary<MessageType, Message> Messages =
            new Dictionary<MessageType, Message>
            {
                { MessageType.Normal, new Message() },
                { MessageType.Warning, new Message(ConsoleColor.Yellow, "Warning: ") },
                { MessageType.Error, new Message(ConsoleColor.Red, "Error: ") }
            };
    }
}
