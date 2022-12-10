namespace Emulator
{
    internal abstract class Command
    {
        public abstract string HelpMessage { get; }

        public abstract void Execute(Stack<string> argStack);
    }
}
