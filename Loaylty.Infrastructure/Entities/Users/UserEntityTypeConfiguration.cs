using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loyalty.Domain.Users;
using Loaylty.Infrastructure.Common;

namespace Loaylty.Infrastructure.Entities.Users
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.OwnsMany(x => x.Points, points =>
            {
                points.ToTable("Points");
                points.HasKey(x => x.Id);
                
            }).Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
