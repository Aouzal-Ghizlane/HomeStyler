using HomeStyler.Api.Constants;
using HomeStyler.Api.Data;
using HomeStyler.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"))) ;




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var mastersGroup = app.MapGroup("/masters")
                    .AllowAnonymous();

mastersGroup.MapGet("/categories", async (AppDbContext context) =>
    TypedResults.Ok(await context.Categories
    .AsNoTracking()
    .ToArrayAsync()
    )
);
mastersGroup.MapGet("/offers", async (AppDbContext context) =>
    TypedResults.Ok(await context.Offers
    .AsNoTracking()
    .ToArrayAsync()
    )
);

app.MapGet("/popular-products", async (AppDbContext context, int? count) =>
{
    if (!count.HasValue || count <= 0)
        count = 6;

    var randomProducts = await context.Products
                            .AsNoTracking()
                            .OrderBy(p => Guid.NewGuid())
                            .Take(count.Value)
                            .Select(Product.DtoSelector)
                            .ToArrayAsync();
    return TypedResults.Ok(randomProducts);
});
app.UseAuthorization();

app.MapControllers();

app.Run();
