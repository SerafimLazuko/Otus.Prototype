using Otus.Protopype.Domain.Models;

namespace Otus.Protopype
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = SeedData.GetItems();
            PromotionalBundle promoBundle = SeedData.GetPromotionalBundles()[0];

            // Клонирование товара
            Item clonedItem = (Item)items[0].Clone();

            // Изменение клонированного товара
            clonedItem = new Item(
                "Banana",
                clonedItem.Category,
                1.2m,
                clonedItem.StockQuantity,
                "TropicalCo",
                new DateTime(2025, 2, 15),
                new DateTime(2025, 8, 15),
                clonedItem.Discount,
                clonedItem.PromotionStartDate,
                clonedItem.PromotionEndDate
            );

            // Клонирование набора акций
            PromotionalBundle clonedPromoBundle = (PromotionalBundle)promoBundle.Clone();

            // Вывод информации о клонированных объектах
            Console.WriteLine("Original Item:");
            PrintItemInfo(items[0]);

            Console.WriteLine("\nModified Cloned Item:");
            PrintItemInfo(clonedItem);

            Console.WriteLine("\nOriginal Promotional Bundle:");
            PrintBundleInfo(promoBundle);

            Console.WriteLine("\nCloned Promotional Bundle:");
            PrintBundleInfo(clonedPromoBundle);
        }

        static void PrintItemInfo(Item item)
        {
            Console.WriteLine($"Name: {item.Name}");
            Console.WriteLine($"Category: {item.Category}");
            Console.WriteLine($"Price: {item.Price}");
            Console.WriteLine($"Stock Quantity: {item.StockQuantity}");
            Console.WriteLine($"Manufacturer: {item.Manufacturer}");
            Console.WriteLine($"Production Date: {item.ProductionDate}");
            Console.WriteLine($"Expiry Date: {item.ExpiryDate}");
            Console.WriteLine($"Discount: {item.Discount}");
            Console.WriteLine($"Promotion Start Date: {item.PromotionStartDate}");
            Console.WriteLine($"Promotion End Date: {item.PromotionEndDate}");
            Console.WriteLine($"Discount Applied Price: {item.DiscountAppliedPrice}");
        }

        static void PrintBundleInfo(PromotionalBundle bundle)
        {
            Console.WriteLine($"Creation Date: {bundle.CreationDate}");
            Console.WriteLine($"Discount: {bundle.Discount}");
            Console.WriteLine($"Promotion Start Date: {bundle.PromotionStartDate}");
            Console.WriteLine($"Promotion End Date: {bundle.PromotionEndDate}");
            Console.WriteLine("Items:");
            foreach (var item in bundle.Items)
            {
                PrintItemInfo((Item)item);
                Console.WriteLine();
            }
        }
    }
}