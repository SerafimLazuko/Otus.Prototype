## Оглавление
- [Интерфейс IClonableShopEntity](#интерфейс-iclonableshopentity)
- [Абстрактный класс ItemBase](#абстрактный-класс-itembase)
- [Класс Item](#класс-item)
- [Абстрактный класс ItemListBase](#абстрактный-класс-itemlistbase)
- [Класс PromotionalBundle](#класс-promotionalbundle)
- [Класс DailyShoppingBundle](#класс-dailyshoppingbundle)
- [Программа для тестирования](#программа-для-тестирования)
- [Получившийся вывод](#получившийся-вывод)
- [Преимущества и недостатки интерфейсов](#преимущества)

### Интерфейс IClonableShopEntity

Интерфейс `IClonableShopEntity<TEntity>` определяет метод `Clone`, который должен возвращать копию текущего объекта типа `TEntity`. Этот интерфейс предназначен для реализации паттерна Прототип и обеспечения функциональности клонирования в рамках домена магазина.

### Абстрактный класс ItemBase

Абстрактный класс `ItemBase` представляет базовый класс для всех товаров в магазине. Он реализует интерфейсы `IClonableShopEntity<ItemBase>` и `ICloneable`, что позволяет создавать копии объектов этого класса. Класс включает основные свойства, такие как название, категория, цена, количество на складе, производитель, дата производства и срок годности. Абстрактный метод `Clone` должен быть реализован в производных классах для создания копии объекта.

```csharp
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
```

### Класс Item

Класс `Item` наследуется от `ItemBase` и добавляет дополнительные свойства, такие как цена со скидкой, размер скидки и даты проведения акции. Метод `Clone` создает копию объекта `Item`.

```csharp
public class Item : ItemBase
{
    public decimal DiscountAppliedPrice { get; set; }
    public decimal Discount { get; set; }
    public DateTime PromotionStartDate { get; set; }
    public DateTime PromotionEndDate { get; set; }

    public Item(
        string name,
        string category,
        decimal price,
        int stockQuantity,
        string manufacturer,
        DateTime productionDate,
        DateTime expiryDate,
        decimal discount,
        DateTime promotionStartDate,
        DateTime promotionEndDate) : base(name,
                                            category,
                                            price,
                                            stockQuantity,
                                            manufacturer,
                                            productionDate,
                                            expiryDate)
    {
        Discount = discount;
        PromotionStartDate = promotionStartDate;
        PromotionEndDate = promotionEndDate;
        DiscountAppliedPrice = price * (1 - discount);
    }

    public Item(Item prototype) : base(prototype) 
    {
        Discount = prototype.Discount;
        PromotionStartDate = prototype.PromotionStartDate;
        PromotionEndDate = prototype.PromotionEndDate;
        DiscountAppliedPrice = prototype.DiscountAppliedPrice;
    }

    public override ItemBase Clone()
    {
        return new Item(this);
    }
}
```

### Абстрактный класс ItemListBase

Абстрактный класс `ItemListBase` представляет базовый класс для списков товаров в магазине. Он реализует интерфейсы `IClonableShopEntity<ItemListBase>` и `ICloneable`, что позволяет создавать копии объектов этого класса. Класс включает свойства, такие как дата создания и список товаров. Абстрактный метод `Clone` должен быть реализован в производных классах для создания копии объекта.

```csharp
public abstract class ItemListBase : IClonableShopEntity<ItemListBase>, ICloneable
{
    protected ItemListBase(DateTime creationDate, List<ItemBase> items)
    {
        CreationDate = creationDate;
        Items = items;
    }

    public ItemListBase(ItemListBase prototype) : this(prototype.CreationDate, prototype.Items) 
    {
    }

    public DateTime CreationDate { get; set; }
    public List<ItemBase> Items { get; set; }

    public abstract ItemListBase Clone();

    object ICloneable.Clone()
    {
        return Clone();
    }
}
```

### Класс PromotionalBundle

Класс `PromotionalBundle` наследуется от `ItemListBase` и добавляет дополнительные свойства, такие как размер скидки и даты проведения акции. Метод `Clone` создает копию объекта `PromotionalBundle`.

```csharp
public class PromotionalBundle : ItemListBase
{
    public PromotionalBundle(
        DateTime creationDate,
        List<ItemBase> items,
        decimal discount,
        DateTime promotionStartDate,
        DateTime promotionEndDate) : base(creationDate, items)
    {
        Discount = discount;
        PromotionStartDate = promotionStartDate;
        PromotionEndDate = promotionEndDate;
    }

    public PromotionalBundle(PromotionalBundle prototype) : base(prototype.CreationDate, prototype.Items)
    {
        Discount = prototype.Discount;
        PromotionStartDate = prototype.PromotionStartDate;
        PromotionEndDate = prototype.PromotionEndDate;
    }

    public decimal Discount { get; set; }
    public DateTime PromotionStartDate { get; set; }
    public DateTime PromotionEndDate { get; set; }

    public override ItemListBase Clone()
    {
        return new PromotionalBundle(this);
    }
}
```

### Класс DailyShoppingBundle

Класс `DailyShoppingBundle` наследуется от `ItemListBase` и добавляет дополнительные свойства, такие как название списка и описание. Метод `Clone` создает копию объекта `DailyShoppingBundle`.

```csharp
public class DailyShoppingBundle : ItemListBase
{
    public string ListName { get; private set; }
    public string Description { get; private set; }

    public DailyShoppingBundle(DateTime creationDate,
                               List<ItemBase> items,
                               string listName,
                               string description) : base(creationDate, items)
    {
        ListName = listName;
        Description = description;
    }

    public DailyShoppingBundle(DailyShoppingBundle prototype) : base(prototype.CreationDate, prototype.Items) 
    {
        ListName = prototype.ListName;
        Description = prototype.Description;
    }

    public override ItemListBase Clone()
    {
        return new DailyShoppingBundle(this);
    }
}
```

## Программа для тестирования

```csharp
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
```

## Получившийся вывод

```plaintext
Original Item:
Name: Apple
Category: Fruits
Price: 1.5
Stock Quantity: 100
Manufacturer: FruitCo
Production Date: 01.01.2025 0:00:00
Expiry Date: 01.06.2025 0:00:00
Discount: 0.1
Promotion Start Date: 01.03.2025 0:00:00
Promotion End Date: 31.03.2025 0:00:00
Discount Applied Price: 1.35

Cloned Item:
Name: Apple
Category: Fruits
Price: 1.5
Stock Quantity: 100
Manufacturer: FruitCo
Production Date: 01.01.2025 0:00:00
Expiry Date: 01.06.2025 0:00:00
Discount: 0.1
Promotion Start Date: 01.03.2025 0:00:00
Promotion End Date: 31.03.2025 0:00:00
Discount Applied Price: 1.35

Modified Cloned Item:
Name: Banana
Category: Fruits
Price: 1.2
Stock Quantity: 100
Manufacturer: TropicalCo
Production Date: 15.02.2025 0:00:00
Expiry Date: 15.08.2025 0:00:00
Discount: 0.1
Promotion Start Date: 01.03.2025 0:00:00
Promotion End Date:
```


### IClonableShopEntity<TEntity>

#### Преимущества:
1. **Сильная типизация**: Интерфейс `IClonableShopEntity<TEntity>` предоставляет более сильную типизацию, так как метод `Clone` возвращает конкретный тип `TEntity`, что устраняет необходимость приведения типов при использовании метода `Clone`.
2. **Гибкость**: Интерфейс может быть адаптирован для любых конкретных требований вашего домена, что делает его более гибким в плане расширяемости и модификации.
3. **Явная реализация**: Интерфейс четко указывает, что класс поддерживает определенную функциональность клонирования конкретного типа сущности.

#### Недостатки:
1. **Зависимость от конкретного домена**: Поскольку интерфейс специфичен для вашего домена, он менее универсален и может потребовать дополнительных усилий при использовании в других проектах.
2. **Дополнительное управление типами**: В некоторых случаях может быть сложно управлять конкретными типами, особенно если у вас есть множество различных сущностей с различными требованиями к клонированию.

### ICloneable

#### Преимущества:
1. **Универсальность**: Интерфейс `ICloneable` является стандартным интерфейсом в .NET и может быть использован для широкого круга задач и проектов.
2. **Простота использования**: Интерфейс `ICloneable` легко понимать и применять, так как он определяет только один метод `Clone`, что упрощает реализацию.
3. **Согласованность**: Использование стандартного интерфейса позволяет вашему коду быть более согласованным с другими частями .NET Framework и сторонними библиотеками.

#### Недостатки:
1. **Низкая типизация**: Метод `Clone` в интерфейсе `ICloneable` возвращает тип `object`, что требует приведения типа при использовании, что может привести к ошибкам в рантайме.
2. **Отсутствие специфичности**: Интерфейс `ICloneable` не предоставляет конкретных требований к клонированию, что может усложнить реализацию специфичных для домена требований.
