namespace Emulator
{
    internal class PrintCommand : Command
    {
        public override string HelpMessage
        {
            get
            {
                return "prints registers";
            }
        }

        public override void Execute(Stack<string> argStack)
        {
            throw new NotImplementedException();
        }
    }
}
