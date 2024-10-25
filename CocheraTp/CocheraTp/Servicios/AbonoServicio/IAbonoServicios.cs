
using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.AbonoServicio
{
    public interface IAbonoServicios
    {
        Task<List<ABONO>> GetAllAbonos();
        Task<List<ABONO>> GetPromedioAbonos();
    }
}
