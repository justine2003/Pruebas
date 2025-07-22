using Abstraciones.Modelos;
using Abstraciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Marcas
{
    public class EleminarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public MarcaResponse marca { get; set; } = default!;

        public EleminarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<ActionResult> OnGet(Guid? id)
        {
            if (id == Guid.Empty) return NotFound();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarca");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            marca = JsonSerializer.Deserialize<MarcaResponse>(resultado, opciones);

            return Page();
        }

        public async Task<ActionResult> OnPost(Guid id) 
        {
            if(id == Guid.Empty) return NotFound();

            if(!ModelState.IsValid) return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EliminarMarca");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }
    }
}
