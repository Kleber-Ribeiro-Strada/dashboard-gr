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
    public class CnhMap : IEntityTypeConfiguration<Cnh>
    {
        public void Configure(EntityTypeBuilder<Cnh> builder)
        {
            
        }
    }
}
