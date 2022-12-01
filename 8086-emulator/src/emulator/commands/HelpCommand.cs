namespace Emulator
{
    internal class HelpCommand : Command
    {
        public override string HelpMessage
        {
            get 
            {
                return "displays this help message";
            }
        }

        public override void Execute(Stack<string> argStack)
        {
            Console.Write("\n");
            foreach (KeyValuePair<string, Command> command in Console.commands)
            {
                Console.Write($"\t{command.Key} - {command.Value.HelpMessage}\n");
            }
            Console.Write("\n");
        }
    }
}
