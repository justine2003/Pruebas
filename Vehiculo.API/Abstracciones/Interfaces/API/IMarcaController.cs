﻿using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IMarcaController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(MarcaRequest marca);
        Task<IActionResult> Editar(Guid Id, MarcaRequest marca);
        Task<IActionResult> Eliminar(Guid Id);
    }
}
