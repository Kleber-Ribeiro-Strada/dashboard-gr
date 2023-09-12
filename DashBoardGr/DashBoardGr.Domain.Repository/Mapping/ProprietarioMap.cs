using DashBoardGr.Domain.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository.Mapping
{
    public class ProprietarioMap : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.HasMany(p => p.Veiculos)
            .WithOne(v => v.Proprietario)
            .HasForeignKey(p => p.ProprietarioId);
        }
    }
}
