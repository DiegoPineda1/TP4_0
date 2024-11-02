using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CocheraTp.Models;
using System.Text.RegularExpressions;

namespace CocheraTp.Repository.CarpetaRepositoryMarca.Interfaces
{
    public interface IMarcaRepository
    {
        Task <bool> GuardarMarca(MARCA marca);
        Task<List<MARCA>> GetAllMarcas();
        //Task<List<MARCA>> GetAllByMarca(string nombreMarca);


    }
}
