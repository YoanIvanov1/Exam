using Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team { Id = 1, Name = "LR", Region = "Europe", Ranking = 1 },
                new Team { Id = 2, Name = "G2", Region = "Europe", Ranking = 2 },
                new Team { Id = 3, Name = "MKOI", Region = "Europe", Ranking = 3 },
                new Team { Id = 4, Name = "KC", Region = "Europe", Ranking = 4 }
            );
        }
    }
}
