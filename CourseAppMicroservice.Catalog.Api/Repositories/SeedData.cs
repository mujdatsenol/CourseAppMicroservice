using CourseAppMicroservice.Catalog.Api.Features.Categories;
using CourseAppMicroservice.Catalog.Api.Features.Courses;

namespace CourseAppMicroservice.Catalog.Api.Repositories;

public static class SeedData
{
    public static async Task AddSeedData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

        if (!dbContext.Categories.Any())
        {
            var categories = new List<Category>
            {
                new() { Id = NewId.NextSequentialGuid(), Name = "Development" },
                new() { Id = NewId.NextSequentialGuid(), Name = "Business" },
                new() { Id = NewId.NextSequentialGuid(), Name = "IT & Software" },
                new() { Id = NewId.NextSequentialGuid(), Name = "Office Productivity" },
                new() { Id = NewId.NextSequentialGuid(), Name = "Personal Development" }
            };
            
            dbContext.Categories.AddRange(categories);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Courses.Any())
        {
            var category = await dbContext.Categories.FirstAsync();
            var randomUserId = Guid.NewGuid();
            List<Course> courses =
            [
                new()
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = "C#",
                    Description = "C# Course",
                    Price = 100,
                    ImageUrl = "https://picsum.photos/id/2/500/350",
                    UserId = randomUserId,
                    Created = DateTime.UtcNow,
                    CategoryId = category.Id,
                    Feature = new Feature
                    {
                        Duration = 10,
                        Rating = 4,
                        EducatorFullName = "John Doe",
                    }
                },
                new()
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = "Java",
                    Description = "Java Course",
                    Price = 200,
                    ImageUrl = "https://picsum.photos/id/4/500/350",
                    UserId = randomUserId,
                    Created = DateTime.UtcNow,
                    CategoryId = category.Id,
                    Feature = new Feature
                    {
                        Duration = 15,
                        Rating = 3,
                        EducatorFullName = "John Doe",
                    }
                },
                new()
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = "Go",
                    Description = "Go Course",
                    Price = 250,
                    ImageUrl = "https://picsum.photos/id/5/500/350",
                    UserId = randomUserId,
                    Created = DateTime.UtcNow,
                    CategoryId = category.Id,
                    Feature = new Feature
                    {
                        Duration = 8,
                        Rating = 5,
                        EducatorFullName = "John Doe",
                    }
                },
                new()
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = "Python",
                    Description = "Python Course",
                    Price = 150,
                    ImageUrl = "https://picsum.photos/id/7/500/350",
                    UserId = randomUserId,
                    Created = DateTime.UtcNow,
                    CategoryId = category.Id,
                    Feature = new Feature
                    {
                        Duration = 6,
                        Rating = 2,
                        EducatorFullName = "John Doe",
                    }
                },
                new()
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = "JavaScript",
                    Description = "JavaScript Course",
                    Price = 100,
                    ImageUrl = "https://picsum.photos/id/20/500/350",
                    UserId = randomUserId,
                    Created = DateTime.UtcNow,
                    CategoryId = category.Id,
                    Feature = new Feature
                    {
                        Duration = 9,
                        Rating = 5,
                        EducatorFullName = "John Doe",
                    }
                }
            ];
            
            dbContext.Courses.AddRange(courses);
            await dbContext.SaveChangesAsync();
        }
    }
}