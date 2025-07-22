using Abstraciones.Modelos;
using Abstraciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Pages.Shared.Vehiculos
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public IList<VehiculoResponse> vehiculos { get; set; } = default!;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<ActionResult> OnGet()
        {
            try 
            {
                string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerVehiculos");
                var cliente = new HttpClient();
                var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

                var respuesta = await cliente.SendAsync(solicitud);
                respuesta.EnsureSuccessStatusCode();
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                vehiculos = JsonSerializer.Deserialize<List<VehiculoResponse>>(resultado, opciones);

                return Page();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
