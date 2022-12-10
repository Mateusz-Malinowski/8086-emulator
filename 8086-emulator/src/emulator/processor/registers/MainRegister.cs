namespace Processor
{
    internal class MainRegister : Register<Int16>
    {
        public override Int16 Value {
            get
            {
                if (BitConverter.IsLittleEndian)
                    return BitConverter.ToInt16(new byte[] { LowRegister.Value, HighRegister.Value }, 0);

                return BitConverter.ToInt16(new byte[] { HighRegister.Value, LowRegister.Value }, 0);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                if (BitConverter.IsLittleEndian)
                {
                    LowRegister.Value = bytes[0];
                    HighRegister.Value = bytes[1];
                    return;
                }

                HighRegister.Value = bytes[0];
                LowRegister.Value = bytes[1];
            }
        }

        public Register<byte> LowRegister { get; private set; }
        public Register<byte> HighRegister { get; private set; }

        public MainRegister(Register<byte> lowRegister, Register<byte> highRegister)
        {
            this.LowRegister = lowRegister;
            this.HighRegister = highRegister;
        }
    }
}
