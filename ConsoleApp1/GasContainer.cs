namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    protected override string containerType => "G";
    
    public double pressure { get; }
    
    public GasContainer(double loadWeight, double height, double containerWeight, double depth, double maxLoad, double pressure) 
        : base(loadWeight, height, containerWeight, depth, maxLoad)
    {
        this.pressure = pressure;
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Kontener {serialNumber} zgłasza zagrożenie: {message}");
    }
    
    public override void LoadContainer(double loadWeight)
    {
        if (loadWeight + this.loadWeight > maxLoad)
        {
            NotifyHazard($"Próba dodania {loadWeight} kg przekracza maksymalną ładowność kontenera ({maxLoad} kg).");
            throw new OverfillException($"Próba dodania {loadWeight} kg przekracza maksymalną ładowność kontenera ({maxLoad} kg).");
        }
        this.loadWeight += loadWeight;
    }

    public override void UnloadContainer()
    {
        loadWeight *= 0.05;
    }
}