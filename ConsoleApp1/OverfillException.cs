namespace ConsoleApp1
{
    public class OverfillException : Exception
    {
        public OverfillException() 
            : base("Przekroczono maksymalną ładowność kontenera.") { }

        public OverfillException(string message) 
            : base(message) { }

        public OverfillException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
