using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : Controller, IModeloController
    {
        private readonly IModeloFlujo _modeloFlujo;
        private readonly ILogger<ModeloController> _logger;

        public ModeloController(IModeloFlujo modeloFlujo, ILogger<ModeloController> logger)
        {
            _modeloFlujo = modeloFlujo;
            _logger = logger;
        }

        [HttpGet("{IdMarca}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid IdMarca)
        {
            var resultado = await _modeloFlujo.Obtener(IdMarca);
            return Ok(resultado);
        }
    }
}
