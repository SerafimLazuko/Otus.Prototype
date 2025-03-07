namespace Otus.Protopype.Domain.Models;

public abstract class ItemBase : IClonableShopEntity<ItemBase>, ICloneable
{
    protected ItemBase(string name,
                       string category,
                       decimal price,
                       int stockQuantity,
                       string manufacturer,
                       DateTime productionDate,
                       DateTime expiryDate)
    {
        Name = name;
        Category = category;
        Price = price;
        StockQuantity = stockQuantity;
        Manufacturer = manufacturer;
        ProductionDate = productionDate;
        ExpiryDate = expiryDate;
    }

    public ItemBase(ItemBase prototype) : this(prototype.Name,
                                               prototype.Category,
                                               prototype.Price,
                                               prototype.StockQuantity,
                                               prototype.Manufacturer,
                                               prototype.ProductionDate,
                                               prototype.ExpiryDate)
    { 
    }

    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Manufacturer { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    public abstract ItemBase Clone();

    object ICloneable.Clone()
    {
        return Clone();
    }
}
