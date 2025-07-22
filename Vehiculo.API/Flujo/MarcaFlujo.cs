﻿using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class MarcaFlujo : IMarcaFlujo
    {
        private readonly IMarcaDA _marcaDA;

        public MarcaFlujo(IMarcaDA marcaDA)
        {
            _marcaDA = marcaDA;
        }

        public Task<Guid> Agregar(MarcaRequest marca)
        {
            return _marcaDA.Agregar(marca);
        }

        public Task<Guid> Editar(Guid Id, MarcaRequest marca)
        {
            return _marcaDA.Editar(Id, marca);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return _marcaDA.Eliminar(Id);
        }

        public Task<IEnumerable<MarcaResponse>> Obtener()
        {
            return _marcaDA.Obtener();
        }

        public Task<MarcaResponse> Obtener(Guid Id)
        {
            return _marcaDA.Obtener(Id);
        }
    }
}
