using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase, IVehiculoController
    {
        private IVehiculoFlujo _Vehiculoflujo;
        private ILogger<VehiculoController> _logger;

        public VehiculoController(IVehiculoFlujo vehiculoflujo, ILogger<VehiculoController> logger)
        {
            _Vehiculoflujo = vehiculoflujo;
            _logger = logger;
        }

        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] VehiculoRequest vehiculo)
        {
            var resultado = await _Vehiculoflujo.Agregar(vehiculo);
            return CreatedAtAction(nameof(Obtener), new {Id=resultado}, null);
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _Vehiculoflujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] VehiculoRequest vehiculo)
        {
            if (!await VerificarVehiculoExiste(Id))
                return NotFound("El vehiculo no existe");
            var resultado = await _Vehiculoflujo.Editar(Id, vehiculo);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await VerificarVehiculoExiste(Id))
                return NotFound("El vehiculo no existe");
            var resultado = await _Vehiculoflujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _Vehiculoflujo.Obtener(Id);
            return Ok(resultado);
        }
        #endregion Operaciones

        #region Helpers       
        private async Task<bool> VerificarVehiculoExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoVehiculoExiste = await _Vehiculoflujo.Obtener(Id);
            if (resultadoVehiculoExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion
    }
}
