namespace ConsoleApp1;

public enum ProductType
{
    Bananas,
    Chocolate,
    Fish,
    Meat,
    IceCream,
    FrozenPizza,
    Cheese,
    Sausages,
    Butter,
    Eggs
}

public static class ProductTemperatureRequirements
{
    public static readonly Dictionary<ProductType, double> RequiredTemperature = new Dictionary<ProductType, double>
    {
        { ProductType.Bananas, 13.3 },
        { ProductType.Chocolate, 18 },
        { ProductType.Fish, 2 },
        { ProductType.Meat, -15 },
        { ProductType.IceCream, -18 },
        { ProductType.FrozenPizza, -30 },
        { ProductType.Cheese, 7.2 },
        { ProductType.Sausages, 5 },
        { ProductType.Butter, 20.5 },
        { ProductType.Eggs, 19 }
    };
}