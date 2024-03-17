using Dominio.Service;

namespace Aplicacion.Commands.Usuario
{
    public class ConsultarUsuario:IMessage
    {
        public int Id { get; set; }
    }
}
