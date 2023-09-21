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
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasMany(v => v.AnaliseRiscoVeiculos)
                .WithOne(arv => arv.Veiculo)
                .HasForeignKey(arv => arv.VeiculoId);
        }
    }
}
