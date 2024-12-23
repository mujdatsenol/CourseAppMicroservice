using CourseAppMicroservice.Basket.Api;
using CourseAppMicroservice.Basket.Api.Features.Baskets;
using CourseAppMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommonServices(typeof(BasketAssembly));
builder.Services.AddVersioning();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

var app = builder.Build();

app.MapBasketGroupEndpoint(app.AddVersionSet());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
