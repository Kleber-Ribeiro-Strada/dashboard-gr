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
    public class AnaliseRiscoMap : IEntityTypeConfiguration<AnaliseRisco>
    {
        public void Configure(EntityTypeBuilder<AnaliseRisco> builder)
        {
            builder.HasMany(ar => ar.AnaliseRiscoVeiculos)
                .WithOne(arv => arv.AnaliseRisco)
                .HasForeignKey(arv => arv.AnaliseRiscoId);
        }
    }
}
