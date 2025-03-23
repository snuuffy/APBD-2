namespace ConsoleApp1;

public class TemperatureException : Exception
{
    public TemperatureException() 
        : base("Temperatura jest zbyt wysoka dla przechowywanego produktu.") { }

    public TemperatureException(string message)
        : base(message) { }

    public TemperatureException(string message, Exception innerException)
        : base(message, innerException) { }
}