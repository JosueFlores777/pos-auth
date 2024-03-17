using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Dtos
{
    public class DtoRespuestaPaginada<T>:IResponse
    {
        public IEnumerable<T> valores { get; set; }
        public Metadata Metadata { get; set; }
    }

    public class Metadata {

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
