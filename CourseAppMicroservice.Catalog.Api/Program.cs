using CourseAppMicroservice.Catalog.Api;
using CourseAppMicroservice.Catalog.Api.Features.Categories;
using CourseAppMicroservice.Catalog.Api.Features.Courses;
using CourseAppMicroservice.Catalog.Api.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExtension();
builder.Services.AddDatabaseService();
builder.Services.AddCommonServices(typeof(CatalogAssembly));
builder.Services.AddVersioning();

var app = builder.Build();

app.AddSeedData().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted
        ? $"Seeding data failed: {x.Exception?.Message}"
        : "Seeding data ok");
});
app.MapCategoryGroupEndpoint(app.AddVersionSet());
app.MapCourseGroupEndpoint(app.AddVersionSet());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
