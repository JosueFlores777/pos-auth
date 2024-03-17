using Dominio.Models;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Seeders
{
   public class UsuarioSeeder
    {
       

        public static void Seed(ModelBuilder builder)
        {
            var usuarioAdmin = new Usuario {Id=Usuario.idUsuarioAdmin, Activo = true, CambiarContrasena = false,IdentificadorAcceso=Usuario.correoUsuarioAdmin, FechaRegistro=DateTime.Now, Nombre="Administrador del sistema", TipoUsuario= "usuario-interno", Contrasena= "52A5D13A7FD60FFFFF425FA65C3830A165969AA983F06C365E48BAC0F8C75CD9",  };
           builder.Entity<Usuario>().HasData(usuarioAdmin);
        }
    }
}
