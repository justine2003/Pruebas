using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class ModeloBase
    {
        [Required(ErrorMessage = "La propiedad IdMarca es requerida.")]
        public Guid IdMarca { get; set; }

        [Required(ErrorMessage = "La propiedad Nombre es requerida.")]
        [StringLength(255, ErrorMessage = "La propiedad Nombre debe tener entre 2 y 255 caracteres.", MinimumLength = 2)]
        public string Nombre { get; set; }
    }

    public class ModeloRequest : ModeloBase
    {
        public Guid IdModelo { get; set; }
    }

    public class ModeloResponse : ModeloBase
    {
        public Guid Id { get; set; }
        public Guid IdMarca { get; set; }
        public string Nombre { get; set; }
    }
}
