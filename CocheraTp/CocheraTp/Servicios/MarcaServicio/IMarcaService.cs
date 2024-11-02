using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.MarcaServicio
{
    public interface IMarcaService
    {
        Task<bool> GuardarMarca(MARCA marca);
        Task<List<MARCA>> GetAllMarcas();
        //Task<List<MARCA>> GetAllByMarca(string nombreMarca);
    }
}
