using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models {
    public class TipoProductoResponse : IEntity {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; }
    }
}
