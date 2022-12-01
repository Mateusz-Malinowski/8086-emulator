namespace Emulator
{
    internal class ExitCommand : Command
    {
        public override string HelpMessage
        {
            get
            {
                return "terminates the program";
            }
        }

        public override void Execute(Stack<string> argStack)
        {
            Environment.Exit(0);
        }
    }
}
