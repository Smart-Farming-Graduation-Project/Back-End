using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Croppilot.Date.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Croppilot.Infrastructure.Configuration;

public class LeasingConfiguration : IEntityTypeConfiguration<Leasing>
{
    public void Configure(EntityTypeBuilder<Leasing> builder)
    {
        builder.HasKey(l => l.Id);
    }
}