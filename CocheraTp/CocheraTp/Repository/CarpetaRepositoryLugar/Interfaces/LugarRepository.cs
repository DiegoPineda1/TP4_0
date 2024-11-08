using CocheraTp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces
{
    public class LugarRepository : ILugarRepository
    {
        private readonly db_cocherasContext _context;
        public LugarRepository(db_cocherasContext context)
        {
            _context = context;
        }

        public async Task<List<LUGARE>> GetAllLugares()
        {
            return await _context.LUGAREs.ToListAsync();
        }


        public async Task<List<LUGARE>> GetLugaresDisponibles()
        {
            return await _context.LUGAREs
                                  .Where(l => l.seccion_uno == false && l.seccion_dos == false)
                                  .ToListAsync();
        }


        public async Task<bool> UpdateLugar(string id, int tipoVehiculo)
        {

            var lugar = await _context.LUGAREs.FindAsync(id);
            if (lugar == null)
            {
                return false;
            }

            switch (tipoVehiculo)
            {
                case 1:
                case 3:
                    lugar.seccion_uno = true;
                    lugar.seccion_dos = true;
                    break;
                case 2:
                    lugar.seccion_uno = true;
                    lugar.seccion_dos = false;
                    break;
                default:
                    return false;
            }
            lugar.id_tipo_vehiculo = tipoVehiculo;
            await _context.SaveChangesAsync();
            return true;
        }

        }
    }
