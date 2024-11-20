using CourseAppMicroservice.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CourseAppMicroservice.Catalog.Api.Repositories;

public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        // Set MongoDB collection name & document key
        builder.ToCollection("courses")
            .HasKey(h => h.Id);
        
        // Do not auto-generate Id in MongoDB or other DB. Set it only in this service with flakes algorithm!
        builder
            .Property(p => p.Id)
            .ValueGeneratedNever();
        
        builder
            .Property(p => p.Name)
            .HasElementName("name")
            .HasMaxLength(100);
        builder
            .Property(p => p.Description)
            .HasElementName("description")
            .HasMaxLength(1000);
        builder
            .Property(p => p.Created)
            .HasElementName("created");
        builder
            .Property(p => p.UserId)
            .HasElementName("userId");
        builder
            .Property(p => p.CategoryId)
            .HasElementName("categoryId");
        builder
            .Property(p => p.ImageUrl)
            .HasElementName("imageUrl")
            .HasMaxLength(200);
        builder
            .Property(p => p.Price)
            .HasElementName("price");
        
        // Ignore parent because MongoDB EntityFramework Core does not recognize dependent relationships.
        builder
            .Ignore(p => p.Category);
        
        // If some child entities has no Id then describe to DB (OwnsOne, OwnsMany)
        builder.OwnsOne(o => o.Feature, feature =>
        {
            feature.HasElementName("feature");
            feature.Property(p => p.Duration)
                .HasElementName("duration");
            feature.Property(p => p.Rating)
                .HasElementName("rating");
            feature.Property(p => p.EducatorFullName)
                .HasElementName("educatorFullName")
                .HasMaxLength(100);
        });
    }
}