using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoDocumento.Interfaces
{
    public interface ITipoDocRepository
    {
        Task<List<TIPOS_DOC>> GetAllTiposDocumento();
    }
}
