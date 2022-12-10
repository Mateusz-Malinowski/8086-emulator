namespace Processor
{
    internal class UnknownRegisterException : Exception
    {
        public UnknownRegisterException(string name)
            : base($"Register \"{name}\" doesn't exists")
        { }
    }
}
