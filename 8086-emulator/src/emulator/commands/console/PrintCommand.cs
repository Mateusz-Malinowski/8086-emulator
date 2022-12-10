using Processor;

namespace Emulator
{
    internal class PrintCommand : ConsoleCommand
    {
        public override string HelpMessage => "prints registers";

        public override void Execute(Stack<string> argStack)
        {
            Console.Write("\n");
            foreach (KeyValuePair<string, Register<Int16>> register in Processor8086.registers16)
            {
                Console.Write($"\t{register.Key} - {register.Value.Value}\n");
            }
            Console.Write("\n");
            foreach (KeyValuePair<string, Register<byte>> register in Processor8086.registers8)
            {
                Console.Write($"\t{register.Key} - {register.Value.Value}\n");
            }
            Console.Write("\n");
        }
    }
}
