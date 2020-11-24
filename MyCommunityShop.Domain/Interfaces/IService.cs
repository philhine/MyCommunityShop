namespace MyCommunityShop.Domain.Interfaces
{
    using System.Threading.Tasks;

    public interface IService<in TIn, TResult>
    {
        Task<TResult> Execute(TIn input);
    }

    public interface IService<TResult>
    {
        Task<TResult> Execute();
    }
}
