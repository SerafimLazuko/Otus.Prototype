namespace Otus.Protopype.Domain.Models;

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
