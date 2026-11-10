using Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasData(
                new Match { Id = 1, TeamA = "LR", TeamB = "G2", Date = new DateTime(2024, 7, 15), Location = "Stadium A" },
                new Match { Id = 2, TeamA = "KC", TeamB = "MKOI", Date = new DateTime(2024, 7, 16), Location = "Stadium B" },
                new Match { Id = 3, TeamA = "LR", TeamB = "KC", Date = new DateTime(2024, 7, 17), Location = "Stadium C" },
                new Match { Id = 4, TeamA = "G2", TeamB = "MKOI", Date = new DateTime(2024, 7, 18), Location = "Stadium D" }
            );
        }
    }
}
