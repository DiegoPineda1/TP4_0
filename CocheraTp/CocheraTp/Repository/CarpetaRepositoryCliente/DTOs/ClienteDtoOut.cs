using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCochera.Repository.CarpetaRepositoryCliente.DTOs
{
    public class ClienteDtoOut
    {
        public int id_cliente { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string contrasenia { get; set; }

        public string dni { get; set; }

        public string? dirrecion { get; set; }

        public string telefono { get; set; }

        public string nro_cuit { get; set; }

        public string e_mail { get; set; }

        public string? iva { get; set; }

        public string? tipoDni { get; set; }
    }
}
