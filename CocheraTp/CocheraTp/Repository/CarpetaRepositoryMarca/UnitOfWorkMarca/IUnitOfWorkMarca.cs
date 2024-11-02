using CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryMarca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryMarca.UnitOfWorkMarca
{
    public interface IUnitOfWorkMarca
    {
        IMarcaRepository MarcaRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
