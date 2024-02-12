using AutoRepairService.Domain.Models;
using AutoRepairService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Infrastructure.Configurations
{
    internal sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => client.Id);

            builder.OwnsOne(client => client.Email, emailBuilder =>
            {
                emailBuilder.WithOwner();

                emailBuilder.Property(email => email.Value)
                .HasColumnName(nameof(Client.Email))
                .HasMaxLength(Email.MaxLength)
                .IsRequired();
            });

            builder.OwnsOne(client => client.Phone, phoneBuilder =>
            {
                phoneBuilder.WithOwner();

                phoneBuilder.Property(phone => phone.Value)
                .HasColumnName(nameof(Client.Phone))
                .HasMaxLength(Phone.MaxLength)
                .IsRequired();
            });

            builder.Property(client => client.FirstName).IsRequired();
            builder.Property(client => client.LastName).IsRequired();
            builder.Property(client => client.Patronomic).IsRequired();
            builder.Property(client => client.Birthday);
            builder.Property(client => client.RegistrationDate).IsRequired();
            builder.Property(client => client.GenderCode).IsRequired();
            builder.Property(client => client.PhotoPath);
        }
    }
}
