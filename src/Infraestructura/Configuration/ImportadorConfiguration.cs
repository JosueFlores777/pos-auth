using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Configuration
{
    public class ImportadorConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Correo).HasMaxLength(50);
            builder.Property(c => c.Identificador).HasMaxLength(50);


            /*builder.HasIndex(c => c.Correo).IsUnique();
            builder.HasIndex(c => c.Identificador).IsUnique();*/
        }
    }
}
