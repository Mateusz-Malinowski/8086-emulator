namespace Emulator
{
    internal static class Console
    {
        public static uint leftMargin = 15;

        public static readonly Dictionary<string, Command> commands = 
            new Dictionary<string, Command>
            {
                { "help", new HelpCommand() },
                { "print", new PrintCommand() },
                { "clear", new ClearCommand() },
                { "exit", new ExitCommand() },
                { "mov", new MovCommand() },
                { "add", new AddCommand() },
            };

        public static void Init()
        {
            Write("Welcome to Intel 8086 emulator!\n");
            Write("\n");
            Write("Type \"help\" to see available commands.\n");
            Write("\n");
            ReadCommands();
        }

        public static void Write(string text = "", MessageType messageType = MessageType.Normal)
        {
            Message? message = Config.Messages.GetValueOrDefault(messageType);

            if (message == null) throw new Exception($"Unmapped message type {messageType}");

            System.Console.ForegroundColor = Config.MessagePrefixColor;
            System.Console.Write($"{Config.MessagePrefix} ");
            System.Console.ResetColor();

            System.Console.ForegroundColor = message.color;
            System.Console.Write($"{message.prefix}{text}");
            System.Console.ResetColor();
        }

        private static void ReadCommands()
        {
            string? input;

            do
            {
                Write("");
                System.Console.ForegroundColor = Config.InputPrefixColor;
                System.Console.Write($"{Config.InputPrefix} ");
                System.Console.ResetColor();

                System.Console.ForegroundColor = Config.InputColor;
                input = System.Console.ReadLine();
                System.Console.ResetColor();
            }
            while (input == "" || input == null);

            Stack<string> stack = new Stack<string>(input.Split(' ').Reverse());
            RunCommand(stack);
            ReadCommands();
        }

        public static void RunCommand(Stack<string> argStack)
        {
            string text = argStack.Pop();
            Command? command;
            
            if (!commands.TryGetValue(text, out command)) // invalid command
            {
                Write($"Command \"{text}\" not found. Type \"help\" to see available commands.\n", MessageType.Error);
                return;
            }

            command.Execute(argStack);
        }
    }
}
