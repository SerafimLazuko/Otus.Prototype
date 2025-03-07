namespace Otus.Prototype.Domain.Models;

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
