using Abstraciones.Modelos;
using Abstraciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Marcas
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;
        public IList<Marca> marcas { get; set; } = default!;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<ActionResult> OnGet()
        {
            try 
            {
                string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarcas");
                var client = new HttpClient();
                var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

                var respuesta = await client.SendAsync(solicitud);
                respuesta.EnsureSuccessStatusCode();
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                marcas = JsonSerializer.Deserialize<IList<Marca>>(resultado, opciones);

                return Page();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}
