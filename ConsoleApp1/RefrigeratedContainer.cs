namespace ConsoleApp1;

public class RefrigeratedContainer : Container
{
    protected override string containerType => "C";
    
    public double currentTemperature { get; set; }
    
    public ProductType? storedProduct { get; set; }
    
    public RefrigeratedContainer(double loadWeight, double height, double containerWeight, double depth, double maxLoad, double currentTemperature, ProductType? storedProduct) 
        : base(loadWeight, height, containerWeight, depth, maxLoad)
    {
        this.currentTemperature = currentTemperature;
        this.storedProduct = storedProduct;
    }
    
    public override void LoadContainer(double loadWeight)
    {
        double requiredTemperature = ProductTemperatureRequirements.RequiredTemperature[storedProduct.Value];
        if (currentTemperature > requiredTemperature)
        {
            throw new TemperatureException($"Temperatura {currentTemperature}°C jest zbyt wysoka...");
        }
        
        base.LoadContainer(loadWeight);
    }
    
    public void LoadContainer(double loadWeight, ProductType? storedProduct)
    {
        if (this.storedProduct.HasValue)
        {
            if (storedProduct.HasValue && this.storedProduct.Value != storedProduct.Value)
            {
                throw new MixedCargoException(
                    $"Kontener przechowuje już {this.storedProduct.Value}, nie można załadować {storedProduct.Value}.");
            }
        }
        else
        {
            if (storedProduct.HasValue)
            {
                this.storedProduct = storedProduct;
            }
        }
        
        if (this.storedProduct.HasValue)
        {
            double requiredTemperature = ProductTemperatureRequirements.RequiredTemperature[this.storedProduct.Value];
            if (currentTemperature > requiredTemperature)
            {
                throw new TemperatureException(
                    $"Temperatura {currentTemperature}°C jest zbyt wysoka dla produktu {this.storedProduct.Value} (wymagane <= {requiredTemperature}°C).");
            }
        }

        base.LoadContainer(loadWeight);
    }

}