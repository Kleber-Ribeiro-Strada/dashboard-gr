using DashBoardGr.Domain.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashBoardGr.Domain.Repository.Mapping
{
    public class MotoristaMap : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.HasMany(m => m.Cnhs)
                .WithOne(cnh => cnh.Motorista)
                .HasForeignKey(cnh => cnh.MotoristaId);

            builder.HasMany(m => m.Analises)
                .WithOne(ar => ar.Motorista)
                .HasForeignKey(ar => ar.MotoristaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
