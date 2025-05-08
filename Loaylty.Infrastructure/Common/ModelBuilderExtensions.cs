﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Loaylty.Infrastructure.Common
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces()
                .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                if (configurationInstance != null) modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
