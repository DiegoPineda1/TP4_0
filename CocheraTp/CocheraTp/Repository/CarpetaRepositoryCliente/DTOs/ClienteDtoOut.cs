using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryCliente.DTOs
{
    public class ClienteDtoOut
    {
        public int id_cliente { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string? Tipo_doc { get; set; }

        public string nro_documento { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }
        [EmailAddress]
        public string e_mail { get; set; }
        public string? Iva { get; set; }
    }
}
