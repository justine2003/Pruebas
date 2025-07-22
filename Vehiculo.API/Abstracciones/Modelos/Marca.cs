using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class MarcaBase
    {
        [Required(ErrorMessage = "El nombre de la marca es requerido.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
        public string Nombre { get; set; }
    }

    public class MarcaRequest : MarcaBase
    {
        public Guid Id { get; set; }
    }

    public class MarcaResponse : MarcaBase
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
