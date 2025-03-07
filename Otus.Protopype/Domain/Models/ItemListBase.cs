namespace Otus.Prototype.Domain.Models;

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
