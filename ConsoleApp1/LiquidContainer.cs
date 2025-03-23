namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    protected override string containerType => "L";
    private bool isHazardous { get; }
    
    public LiquidContainer(double loadWeight, double height, double containerWeight, double depth, double maxLoad, bool isHazardous) 
        : base(loadWeight, height, containerWeight, depth, maxLoad)
    {
        this.isHazardous = isHazardous;
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Kontener {serialNumber} zgłasza zagrożenie: {message}");
    }
    
    public override void LoadContainer(double loadWeight)
    {
        double allowedLoad = isHazardous ? maxLoad * 0.5 : maxLoad * 0.9;
        
        if (loadWeight + this.loadWeight > allowedLoad)
        {
            NotifyHazard($"Próba dodania {loadWeight} kg przekracza maksymalną ładowność kontenera ({allowedLoad} kg).");
            throw new OverfillException($"Ładunek {loadWeight} kg przekracza dozwolony limit {allowedLoad} kg.");
        }
        
        this.loadWeight += loadWeight;
    }

}