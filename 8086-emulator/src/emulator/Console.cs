namespace Emulator {
    enum MessageType
    {
        Normal,
        Warning,
        Error
    }
        
    internal static class Console
    {
        public static uint leftMargin = 15;

        private static Dictionary<MessageType, System.ConsoleColor> messageTypeToColor = 
            new Dictionary<MessageType, System.ConsoleColor>
            {
                { MessageType.Normal, ConsoleColor.White },
                { MessageType.Warning, ConsoleColor.Yellow },
                { MessageType.Error, ConsoleColor.Red },
            };

        private static Dictionary<string, Action<Stack<string>>> commands = 
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
            System.Console.ForegroundColor = messageTypeToColor.GetValueOrDefault(messageType);
            System.Console.Write($"$ {text}", messageType);
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
                Write(">> ");
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
                WriteLine($"Command \"{command}\" not found", MessageType.Error);
                WriteLine("Type \"help\" to see available commands.", MessageType.Normal);
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
