using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraciones.Modelos
{
    public class Marca
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre de la marca es requerido")]
        public string Nombre { get; set; }
    }

    public class MarcaRequest : Marca
    {
        public Guid Id { get; set; }
    }

    public class MarcaResponse : Marca
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
    }
}
