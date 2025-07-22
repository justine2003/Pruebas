using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class MarcaDA : IMarcaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public MarcaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(MarcaRequest marca)
        {
            string query = @"AgregarMarca";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id = Guid.NewGuid(),
                Nombre = marca.Nombre,
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, MarcaRequest marca)
        {
            await VerificarMarcaExistente(Id);
            string query = @"EditarMarca";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id = Id,
                Nombre = marca.Nombre,
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarMarcaExistente(Id);
            string query = @"EliminarMarca";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new { id = Id });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<MarcaResponse>> Obtener() 
        {
            string query = @"ObtenerMarcas";
            var resultadoConsulta = await _sqlConnection.QueryAsync<MarcaResponse>(query);
            return resultadoConsulta;
        }

        public async Task<MarcaResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerMarca";
            var resultadoConsulta = await _sqlConnection.QuerySingleAsync<MarcaResponse>(query, new { id = Id });
            return resultadoConsulta;
        }

        private async Task VerificarMarcaExistente(Guid Id)
        {
            MarcaResponse? resultadoConsultarMarca = await Obtener(Id);

            if(resultadoConsultarMarca == null) { throw new Exception("No se encontro el vehiculo"); }
        }
    }
}
