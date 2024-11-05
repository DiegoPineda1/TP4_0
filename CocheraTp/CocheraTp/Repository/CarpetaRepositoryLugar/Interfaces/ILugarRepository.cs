
using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces
{
    public interface ILugarRepository
    {
        Task<List<LUGARE>> GetAllLugares();
        Task<List<LUGARE>> GetLugaresDisponibles();
        Task<bool> UpdateLugar(string id);
    }
}
