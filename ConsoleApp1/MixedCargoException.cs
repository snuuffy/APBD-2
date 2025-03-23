namespace ConsoleApp1;

public class MixedCargoException : Exception
{
    public MixedCargoException()
        : base("Kontener może przechowywać tylko jeden rodzaj produktu.") { }

    public MixedCargoException(string message)
        : base(message) { }

    public MixedCargoException(string message, Exception innerException)
        : base(message, innerException) { }
}