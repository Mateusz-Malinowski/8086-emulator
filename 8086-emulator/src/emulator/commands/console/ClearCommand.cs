namespace Emulator
{
    internal class ClearCommand : ConsoleCommand
    {
        public override string HelpMessage => "clears console";

        public override void Execute(Stack<string> argStack)
        {
            System.Console.Clear();
        }
    }
}
