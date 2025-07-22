using Abstraciones.Modelos;
using Abstraciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Marcas
{
    public class EditarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public EditarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public MarcaResponse MarcaResponse { get; set; }
        [BindProperty]
        public Guid marcaSeleccionada { get; set; }
        [BindProperty]
        public Guid marca { get; set; }

        public async Task<ActionResult> OnPost(Guid id) 
        {
            if(!ModelState.IsValid) return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EditarMarca");
            var cliente = new HttpClient();
            var respuesta = await cliente.PutAsJsonAsync<MarcaRequest>(String.Format(endpoint, MarcaResponse.Id),
                new MarcaRequest
                {
                    Nombre = MarcaResponse.Nombre,
                });
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }

        public async Task<ActionResult> OnGet(Guid? id)
        {
            if (id == Guid.Empty) return NotFound();
            
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarca");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK) 
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                MarcaResponse = JsonSerializer.Deserialize<MarcaResponse>(resultado, opciones);
            }

            return Page();
        }
    }
}
