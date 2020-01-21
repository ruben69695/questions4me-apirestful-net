using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using questions4me_apirestful_net.Models;

namespace questions4me_apirestful_net.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("questions")
                .HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .HasColumnName("_id")
                .ValueGeneratedOnAdd();

            builder.Property(q => q.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("varchar(220)")
                .HasMaxLength(220);

            builder.Property(q => q.Content)
                .HasColumnName("content")
                .HasColumnType("varchar(550)")
                .HasMaxLength(450);

            builder.Property(q => q.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz");

            builder.Property(q => q.AnsweredAt)
                .HasColumnName("answer_at")
                .HasColumnType("timestamptz")
                .HasDefaultValue(null);
        }
    }
}