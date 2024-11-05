using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.UnitOfWorkFormaPago;


namespace CocheraTp.Servicios.FormaPagoServicio
{
    public class FormaPagoService : IFormaPagoService
    {
        private readonly IUnitOfWorkFormaPago _unitOfWork;

        public FormaPagoService(IUnitOfWorkFormaPago unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FORMAS_DE_PAGO>> GetAllFormaPago()
        {
            return await _unitOfWork.FormaPagoRepository.GetAllFormaPago();
        }
    }
}
