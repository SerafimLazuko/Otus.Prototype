using Otus.Prototype.Domain.Models;

namespace Otus.Prototype;

public static class SeedData
{
    public static List<Item> GetItems()
    {
        return new List<Item>
            {
                new Item(
                    "Apple",
                    "Fruits",
                    1.5m,
                    100,
                    "FruitCo",
                    new DateTime(2025, 1, 1),
                    new DateTime(2025, 6, 1),
                    0.1m,
                    new DateTime(2025, 3, 1),
                    new DateTime(2025, 3, 31)
                ),
                new Item(
                    "Orange",
                    "Fruits",
                    1.8m,
                    150,
                    "CitrusCo",
                    new DateTime(2025, 2, 1),
                    new DateTime(2025, 7, 1),
                    0.15m,
                    new DateTime(2025, 3, 1),
                    new DateTime(2025, 3, 31)
                )
            };
    }

    public static List<PromotionalBundle> GetPromotionalBundles()
    {
        List<ItemBase> promoItems = GetItems().ConvertAll(item => (ItemBase)item);
        return new List<PromotionalBundle>
            {
                new PromotionalBundle(
                    DateTime.Now,
                    promoItems,
                    0.15m,
                    new DateTime(2025, 3, 1),
                    new DateTime(2025, 3, 31)
                )
            };
    }
}
