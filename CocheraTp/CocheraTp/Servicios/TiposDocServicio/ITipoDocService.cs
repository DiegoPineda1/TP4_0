using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.TiposDocServicio
{
    public interface ITipoDocService
    {
        Task<List<TIPOS_DOC>> GetAllTiposDocumento();
    }
}
