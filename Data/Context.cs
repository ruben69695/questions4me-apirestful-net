using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

using questions4me_apirestful_net.Data.Configurations;
using questions4me_apirestful_net.Models;

namespace questions4me_apirestful_net.Data
{
    /// <summary>
    /// Entity EFCore Database Context
    /// </summary>
    public class Context : DbContext
    {
        public virtual DbSet<Question> Questions { get; set; }

        public Context([NotNullAttribute] DbContextOptions options) : base(options)
        { }

        public virtual void Commit() {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(QuestionConfiguration)));
        }
    }
}