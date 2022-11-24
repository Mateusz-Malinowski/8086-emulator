namespace Emulator
{
    internal static class Console
    {
        public static uint leftMargin = 15;

        private static readonly Dictionary<string, Action<Stack<string>>> commands = 
            new Dictionary<string, Action<Stack<string>>>
            {
                { "help", Help },
                { "print", Print } 
            };

        public static void Init()
        {
            WriteLine("Welcome to Intel 8086 emulator!");
            WriteLine();
            WriteLine("Type \"help\" to see available commands.");
            WriteLine();
            ReadCommands();
        }

        public static void Write(string text = "", MessageType messageType = MessageType.Normal)
        {
            Message? message = Config.Messages.GetValueOrDefault(messageType);

            if (message == null) throw new Exception($"Unmapped message type {messageType}");

            System.Console.ForegroundColor = Config.MessagePrefixColor;
            System.Console.Write($"{Config.MessagePrefix} ");

            System.Console.ForegroundColor = message.color;
            System.Console.Write($"{message.prefix}{text}");
            System.Console.ResetColor();
        }

        public static void WriteLine(string text = "", MessageType messageType = MessageType.Normal)
        {
            Write($"{text}\n", messageType);
        }

        private static void ReadCommands()
        {
            string? input;

            do
            {
                Write("");
                System.Console.ForegroundColor = Config.InputPrefixColor;
                System.Console.Write($"{Config.InputPrefix} ");
                System.Console.ResetColor(); // nie resetuje?

                input = System.Console.ReadLine();
            }
            while (input == "" || input == null);

            Stack<string> stack = new Stack<string>(input.Split(' ').Reverse());
            RunCommand(stack);
            ReadCommands();
        }

        public static void RunCommand(Stack<string> argStack)
        {
            string command = argStack.Pop();
            Action<Stack<string>>? method;

            if (!commands.TryGetValue(command, out method)) // invalid command
            {
                WriteLine($"Command \"{command}\" not found. Type \"help\" to see available commands.", MessageType.Error);
                return;
            }

            method(argStack);
        }

        private static void Help(Stack<string> argStack)
        {

        }

        private static void Print(Stack<string> argStack)
        {
            
        }
    }
}
