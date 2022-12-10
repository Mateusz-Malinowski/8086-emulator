namespace Processor
{
    internal static class Processor8086
    {
        public static readonly Dictionary<string, Register<byte>> registers8 = new Dictionary<string, Register<byte>>();
        public static readonly Dictionary<string, Register<Int16>> registers16 = new Dictionary<string, Register<Int16>>();

        static Processor8086()
        {
            registers8.Add("AH", new Register<byte>()); 
            registers8.Add("AL", new Register<byte>()); 
            registers16.Add("AX", new MainRegister(registers8["AL"], registers8["AH"]));
            registers8.Add("BH", new Register<byte>()); 
            registers8.Add("BL", new Register<byte>());
            registers16.Add("BX", new MainRegister(registers8["BL"], registers8["BH"]));
            registers8.Add("CH", new Register<byte>());
            registers8.Add("CL", new Register<byte>());
            registers16.Add("CX", new MainRegister(registers8["CL"], registers8["CH"]));
            registers8.Add("DH", new Register<byte>());
            registers8.Add("DL", new Register<byte>());
            registers16.Add("DX", new MainRegister(registers8["DL"], registers8["DH"]));
        }

        /// <summary>
        /// Copies data from one register to another
        /// </summary>
        public static void mov(string destinationRegisterName, string sourceRegisterName)
        {
            dynamic destinationRegister = GetRegisterByName(destinationRegisterName);
            dynamic sourceRegister = GetRegisterByName(sourceRegisterName);

            destinationRegister.Value = Convert.ChangeType(sourceRegister.Value, destinationRegister.Value.GetType());
        }

        public static void mov(string destinationRegisterName, int value)
        {
            dynamic destinationRegister = GetRegisterByName(destinationRegisterName);

            destinationRegister.Value = Convert.ChangeType(value, destinationRegister.Value.GetType());
        }

        public static void add(string destinationRegisterName, string sourceRegisterName)
        {
            dynamic destinationRegister = GetRegisterByName(destinationRegisterName);
            dynamic sourceRegister = GetRegisterByName(sourceRegisterName);

            destinationRegister.Value += Convert.ChangeType(sourceRegister.Value, destinationRegister.Value.GetType());
        }

        public static void add(string destinationRegisterName, int value)
        {
            dynamic destinationRegister = GetRegisterByName(destinationRegisterName);

            destinationRegister.Value += Convert.ChangeType(value, destinationRegister.Value.GetType());
        }

        private static dynamic GetRegisterByName(string name)
        {
            bool isRegister8Bit = registers8.ContainsKey(name);
            bool isRegister16Bit = registers16.ContainsKey(name);

            if (!isRegister8Bit && !isRegister16Bit) throw new UnknownRegisterException(name);

            if (isRegister8Bit) return registers8[name];

            return registers16[name];
        }
    }
}
