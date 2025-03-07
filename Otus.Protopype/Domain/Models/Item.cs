namespace Otus.Prototype.Domain.Models;

public class Item : ItemBase, ICloneable
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
