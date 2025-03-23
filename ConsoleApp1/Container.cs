namespace ConsoleApp1;

public abstract class Container
{
    protected double loadWeight { get; set; }
    protected double height { get; }
    protected double containerWeight { get; }
    protected double depth { get; }
    public string serialNumber { get; }
    protected double maxLoad { get; }

    private static int containerNumber = 0;
    
    protected abstract string containerType { get; }

    protected Container(double loadWeight, double height, double containerWeight, double depth, double maxLoad)
    {
        if (loadWeight > maxLoad)
        {
            throw new OverfillException($"Początkowy ładunek ({loadWeight} kg) nie może przekraczać maksymalnej ładowności ({maxLoad} kg).");
        }
        
        this.loadWeight = loadWeight;
        this.height = height;
        this.containerWeight = containerWeight;
        this.depth = depth;
        this.maxLoad = maxLoad;
        serialNumber = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        return $"KON-{containerType}-{containerNumber++}";
    }
    
    public virtual void LoadContainer(double loadWeight)
    {
        if (loadWeight + this.loadWeight > maxLoad)
        {
            throw new OverfillException($"Próba dodania {loadWeight} kg przekracza maksymalną ładowność kontenera ({maxLoad} kg).");
        }
        this.loadWeight += loadWeight;
    }

    public virtual void UnloadContainer()
    {
        loadWeight = 0;
    }
    
    public double TotalWeightInKg => containerWeight + loadWeight;
    
    public override string ToString()
    {
        return $"Kontener {serialNumber} typu {containerType}: Ładunek = {loadWeight} kg, Maksymalna ładowność = {maxLoad} kg.";
    }

    
}