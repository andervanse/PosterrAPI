
namespace Posterr.Domain.Interfaces
{
    public interface IRepository<T>: IUnitOfWork where T : EntityBase
    {
    }
}
