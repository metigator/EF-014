using EF014.SeedDataModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF014.SeedDataModel.Data.Config
{
    internal class IndividualConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder.ToTable("Individuals");
            builder.HasData(SeedData.LoadIndividuals());
        }
    }
}
