﻿using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.TipoVehiculoService
{
    public interface ITipoVehiculoService
    {
        Task<List<TIPO_VEHICULO>> GetAllTipoVehiculo();
    }
}