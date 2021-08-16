using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;

namespace CosmosTest.EFCore
{
    public class EFCoreToCosmos
    {
        /*
         *  Notice that there is not slash on this "partitionKeyPath." 
         *  That is because I am searching based on a field instead of 
         *  using the internal cosmos partition key functionality that I 
         *  use in CosmosLibToCosmos
         */
        private readonly string _partitionKeyPath = "partitionKeyPathField";
        DbSet<CosmosDocumentType> docs = new MyDBContext().Set<CosmosDocumentType>();
        public List<CosmosDocumentType> GetAll()
        {
            return docs.Where(x => x.Type == _partitionKeyPath)
                       .Select(y => new CosmosDocumentType() { Id = y.Id, Name = y.Name, Type = y.Type })
                       .ToList();
        }
    }

    public class MyDBContext : DbContext
    {
        private readonly string _cosmosDbConnectionString = "";
        private readonly string _containerId = "";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseCosmos(
                _cosmosDbConnectionString, 
                _containerId);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultContainer(_containerId);
            new CosmosTypeConfiguration().Configure(modelBuilder.Entity<CosmosDocumentType>());
        }
    }

    public class CosmosTypeConfiguration : IEntityTypeConfiguration<CosmosDocumentType>
    {
        public void Configure(EntityTypeBuilder<CosmosDocumentType> builder)
        {
            builder.HasNoDiscriminator();
            builder.Property(m => m.Id)
                .ToJsonProperty("id");
            builder.Property(m => m.Name)
                .ToJsonProperty("name");
            builder.Property(m => m.Type)
                .ToJsonProperty("type");
        }
    }

    public class CosmosDocumentType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
