using Dominio.Especificaciones;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Models.Regla
{
    class ImportadoresCorreoEnviado : IImportadoresCorreoEnviado
    {
        private readonly IImportadorRepository importadoreRepo;

        public ImportadoresCorreoEnviado(IImportadorRepository importadoreRepo)
        {
            this.importadoreRepo = importadoreRepo;
        }
        public bool VerificarCorreoEnviado(int id)
        {
            var user = importadoreRepo.Filter(new BuscarImportadorConCorreoEnviado(id));
            return user.Count() > 0;
        }

    }

    public interface IImportadoresCorreoEnviado:IRegla {
        bool VerificarCorreoEnviado(int id);
    }

}