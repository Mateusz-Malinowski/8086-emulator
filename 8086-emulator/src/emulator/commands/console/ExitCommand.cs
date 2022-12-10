namespace Emulator
{
    internal class ExitCommand : ConsoleCommand
    {
        public override string HelpMessage => "terminates the program";

        public override void Execute(Stack<string> argStack)
        {
            Environment.Exit(0);
        }
    }
}
