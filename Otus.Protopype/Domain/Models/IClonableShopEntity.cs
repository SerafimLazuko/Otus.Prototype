namespace Otus.Prototype.Domain.Models;

public interface IClonableShopEntity<TEntity>
{
    public TEntity Clone();
}
