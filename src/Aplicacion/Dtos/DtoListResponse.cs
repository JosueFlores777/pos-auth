using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Dtos
{
    public class DtoListResponse<T>:IResponse
    {
        public IList<T> Lista { get; set; }
    }

}
