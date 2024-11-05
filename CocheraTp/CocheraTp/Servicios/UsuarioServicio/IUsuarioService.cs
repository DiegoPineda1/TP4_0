using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.UsuarioServicio
{
    public interface IUsuarioService
    {
        Task<List<USUARIO>> GetAllUsuario();
    }
}
