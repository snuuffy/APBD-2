namespace ConsoleApp1;

public class ContainerShip
{
    public List<Container> Containers { get; }
    public double maxSpeed { get; }
    public double maxWeight { get; }
    public int maxContainers { get; }
    
    public ContainerShip(double maxSpeed, double maxWeight, int maxContainers)
    {
        this.maxSpeed = maxSpeed;
        this.maxWeight = maxWeight;
        this.maxContainers = maxContainers;
        Containers = new List<Container>();
    }

    public void AddContainer(Container container)
    {
        if (Containers.Any(c => c.serialNumber == container.serialNumber))
        {
            throw new Exception("Kontener o tym numerze seryjnym jest już załadowany na statek.");
        }
        
        if (Containers.Count >= maxContainers)
        {
            throw new Exception($"Statek nie może pomieścić więcej niż {maxContainers} kontenerów.");
        }
        
        double currentTotalWeightKg = Containers.Sum(c => c.TotalWeightInKg);
        double newTotalWeightKg = currentTotalWeightKg + container.TotalWeightInKg;
        double newTotalWeightTons = newTotalWeightKg / 1000.0;
        
        if (newTotalWeightTons > maxWeight)
        {
            throw new Exception($"Statek nie może pomieścić więcej niż {maxWeight} ton.");
        }
        
        Containers.Add(container);
        
    }

    public void AddContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }
    
    public void RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.serialNumber == serialNumber);
        if (container == null)
        {
            throw new Exception($"Nie znaleziono kontenera o numerze {serialNumber}.");
        }
        Containers.Remove(container);
    }

    
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = Containers.FindIndex(c => c.serialNumber == serialNumber);
        if (index == -1)
        {
            throw new Exception($"Nie znaleziono kontenera o numerze {serialNumber}.");
        }
        
        Containers.RemoveAt(index);
        AddContainer(newContainer);
    }
    
    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.serialNumber == serialNumber);
        if (container == null)
        {
            throw new Exception($"Nie znaleziono kontenera o numerze {serialNumber}.");
        }
            
        Containers.Remove(container);
        targetShip.AddContainer(container);
    }

    public bool isReadyToSail()
    {
        return Containers.Count > 0;
    }
    
    public override string ToString()
    {
        return $"Statek: MaxSpeed = {maxSpeed} węzłów, Kontenery: {Containers.Count}/{maxContainers}, Łączna waga: {Containers.Sum(c => c.TotalWeightInKg)/1000.0} ton, Maksymalne obciążenie: {maxWeight} ton.";
    }
}