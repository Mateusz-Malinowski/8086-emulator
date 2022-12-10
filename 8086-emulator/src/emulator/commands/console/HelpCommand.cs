namespace Emulator
{
    internal class HelpCommand : ConsoleCommand
    {
        public override string HelpMessage => "displays this help message";

        public override void Execute(Stack<string> argStack)
        {
            List<string> consoleMessages = new List<string>();
            List<string> processorMessages = new List<string>();

            foreach (KeyValuePair<string, Command> command in Console.commands)
            {
                string message = $"\t{command.Key} - {command.Value.HelpMessage}\n";

                if (command.Value is ConsoleCommand) consoleMessages.Add(message);
                else if (command.Value is ProcessorCommand) processorMessages.Add(message);
            }

            Console.Write("\n");
            Console.Write("CONSOLE:\n");
            foreach (string message in consoleMessages) Console.Write(message);
            Console.Write("\n");
            Console.Write("PROCESSOR:\n");
            foreach (string message in processorMessages) Console.Write(message);
            Console.Write("\n");
        }
    }
}
