using CocheraTp.Repository.CarpetaRepositoryFormaPago.Interfaces;

namespace CocheraTp.Repository.CarpetaRepositoryFormaPago.UnitOfWorkFormaPago
{
    public interface IUnitOfWorkFormaPago
    {
        IFormaPagoRepository FormaPagoRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
