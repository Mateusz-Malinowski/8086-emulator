using Processor;

namespace Emulator
{
    internal class MovCommand : ProcessorCommand
    {
        public override string HelpMessage =>
            "Copies source to destination (source can be a numeric value) " +
            "Usage: mov [destination] [source | value]";

        public override void Execute(Stack<string> argStack)
        {
            try
            {
                string destination = argStack.Pop();
                string source = argStack.Pop();

                bool isNumeric = int.TryParse(source, out int value);

                if (isNumeric) Processor8086.mov(destination, value);
                else Processor8086.mov(destination, source);
            }
            catch (Exception exception)
            {
                Console.Write($"{exception.Message}\n", MessageType.Error);
            }
        }
    }
}
