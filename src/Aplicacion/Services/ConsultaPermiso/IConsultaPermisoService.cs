using Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.ConsultaPermiso
{
    public interface IConsultaPermisoService
    {
        IEnumerable<DtoPermiso> Estructurar(IEnumerable<DtoPermiso> Permisos);
    }
}
