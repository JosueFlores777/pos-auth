using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarImportadorPorIdentificadorYAccesoAprobado : ISpecification<Importardor>
    { 
    private readonly string identificador;

    public BuscarImportadorPorIdentificadorYAccesoAprobado(string identificador)
    {
        this.identificador = identificador;
    }

    public Func<Importardor, bool> Traer()
    {
        return new Func<Importardor, bool>(c => c.AccesoAprobado==true && c.Identificador.Replace("-", "").Trim() == identificador.Replace("-", "").Trim());

    }
}
}