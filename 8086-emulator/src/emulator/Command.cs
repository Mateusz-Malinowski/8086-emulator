namespace Emulator
{
    internal abstract class Command
    {
        // TODO: CommandType (Console or Processor, seperate them in help message)
        public abstract string HelpMessage { get; }
        public abstract void Execute(Stack<string> argStack);
    }
}
