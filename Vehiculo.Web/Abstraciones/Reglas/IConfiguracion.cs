﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraciones.Reglas
{
    public interface IConfiguracion
    {
        string ObtenerMetodo(string seccion, string nombre);
    }
}
