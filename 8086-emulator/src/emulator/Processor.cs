namespace Emulator
{
    internal class Processor
    {
        public readonly Dictionary<string, int> Registers = new Dictionary<string, int>
        {
            { "AX", 0 },
            { "BX", 0 },
            { "CX", 0 },
            { "DX", 0 },
        };

        /// <summary>
        /// Copies data from one register to another
        /// </summary>
        public void mov(string toRegister, string fromRegister)
        {
            // TODO: AX: 16 bit, AH: first 8 bits, AL: last 8 bits etc.
            throw new NotImplementedException();
        }
    }
}
