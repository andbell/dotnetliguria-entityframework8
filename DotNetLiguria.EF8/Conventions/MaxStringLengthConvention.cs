﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DotNetLiguria.EF8.Conventions;

public class MaxStringLengthConvention : IModelFinalizingConvention
{
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        foreach (var property in modelBuilder.Metadata.GetEntityTypes()
                     .SelectMany(entityType => entityType.GetDeclaredProperties()
                             .Where(property => property.ClrType == typeof(string))))
        {
            property.Builder.HasMaxLength(340);
        }
    }
}
