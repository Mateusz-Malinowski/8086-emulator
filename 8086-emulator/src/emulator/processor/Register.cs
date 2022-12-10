namespace Processor
{
    internal class Register<T> where T : System.Numerics.IBinaryInteger<T> 
    {
        public virtual T? Value { get; set; }
    }
}
