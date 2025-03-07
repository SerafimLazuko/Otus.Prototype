namespace Otus.Protopype.Domain.Models;

public interface IClonableShopEntity<TEntity>
{
    public TEntity Clone();
}
