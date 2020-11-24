namespace MyCommunityShop.Domain.Interfaces
{
    public interface IFactory<in TIn, TResult>
    {
        TResult Get(TIn offers);
    }
}
