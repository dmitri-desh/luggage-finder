using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LuggageFinder.Domain;

namespace LuggageFinder.Persistence.EntityTypeConfigurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.TrackNumber).IsRequired().HasMaxLength(10);
            builder.Property(x => x.DestinationAddress).HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.ModificationDate);

            builder.Property(x => x.UserId).IsRequired();
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.ArrivalAirportId);
            builder.HasOne(x => x.ArrivalAirport)
                .WithMany()
                .HasForeignKey(x => x.ArrivalAirportId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.DepartureAirportId);
            builder.HasOne(x => x.DepartureAirport)
                .WithMany()
                .HasForeignKey(x => x.DepartureAirportId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
