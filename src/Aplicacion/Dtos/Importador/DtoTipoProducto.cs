using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Dtos.Importador
{
    public class DtoTipoProducto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; }
    }
}
