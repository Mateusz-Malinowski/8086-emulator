namespace Emulator
{
    enum MessageType
    {
        Normal,
        Warning,
        Error
    }

    internal class Message
    {
        public readonly ConsoleColor color;
        public readonly string prefix;

        public Message(ConsoleColor color = ConsoleColor.White, string prefix = "")
        {
            this.color = color;
            this.prefix = prefix;
        }
    }
}
