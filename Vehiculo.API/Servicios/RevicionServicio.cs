using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Registro;
using Abstracciones.Modelos.Servicios.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios
{
    public class RevicionServicio: IRevisionServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpclient;
       
        public RevicionServicio(IConfiguracion configuracion, IHttpClientFactory httpclient)
        {
            _configuracion = configuracion;
            _httpclient = httpclient;
        }

        public async Task<Revision> Obtener(string Placa)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointRevision", "ObtenerRevision");
            var servicioRegistro = _httpclient.CreateClient("ServicioRevision");
            var respuesta = await servicioRegistro.GetAsync(string.Format(endPoint, Placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Revision>>(resultado, opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
