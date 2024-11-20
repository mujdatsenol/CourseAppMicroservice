using CourseAppMicroservice.Catalog.Api.Features.Categories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CourseAppMicroservice.Catalog.Api.Repositories;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Set MongoDB collection name & document key
        builder
            .ToCollection("categories")
            .HasKey(x => x.Id);
        
        // Do not auto-generate Id in MongoDB or other DB. Set it only in this service with flakes algorithm!
        builder
            .Property(p => p.Id)
            .ValueGeneratedNever();
        
        // Ignore parent because MongoDB EntityFramework Core does not recognize dependent relationships.
        builder
            .Ignore(p => p.Courses);
    }
}