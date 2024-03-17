using Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.ConsultaPermiso
{
    public class ConsultaPermisoService : IConsultaPermisoService
    {
        public IEnumerable<DtoPermiso> Estructurar(IEnumerable<DtoPermiso> Permisos)
        {
            var padres = Permisos.Where(c=>c.PermisoPadre==null);
            foreach (var permiso in padres)getHijos(permiso,Permisos);
            return padres;
        }

        private void getHijos(DtoPermiso permiso,IEnumerable<DtoPermiso> dtoPermisos) {

            var hijos = dtoPermisos.Where(c=>c.PermisoPadre==permiso.Id);
            if (hijos == null || hijos.Count() == 0) return;
            foreach (var hijo in hijos)getHijos(hijo, dtoPermisos);
            permiso.Hijos = hijos;
        }
    }
}
