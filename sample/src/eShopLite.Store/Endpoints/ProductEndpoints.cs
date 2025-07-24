using eShopLite.Store.DataEntities;
using eShopLite.Store.ProductData;

using Microsoft.EntityFrameworkCore;

namespace eShopLite.Store.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/products");

        group.MapPost("/", async (Product product, ProductDbContext db) =>
        {
            db.Product.Add(product);
            await db.SaveChangesAsync();

            return Results.Created($"/api/products/{product.Id}", product);
        })
        .WithTags("products")
        .WithName("CreateProduct")
        .Produces<Product>(StatusCodes.Status201Created);

        group.MapGet("/", async (ProductDbContext db) =>
        {
            return await db.Product.ToListAsync();
        })
        .WithTags("products")
        .WithName("GetAllProducts")
        .Produces<List<Product>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async  (int id, ProductDbContext db) =>
        {
            var product = await db.Product
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(model => model.Id == id);

            return product is Product model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithTags("products")
        .WithName("GetProductById")
        .Produces<Product>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async  (int id, Product product, ProductDbContext db) =>
        {
            var affected = await db.Product
                                   .Where(model => model.Id == id)
                                   .ExecuteUpdateAsync(setters => setters
                                       .SetProperty(m => m.Id, product.Id)
                                       .SetProperty(m => m.Name, product.Name)
                                       .SetProperty(m => m.Description, product.Description)
                                       .SetProperty(m => m.Price, product.Price)
                                       .SetProperty(m => m.ImageUrl, product.ImageUrl)
                                   );

            return affected == 1 ? Results.Ok() : Results.NotFound();
        })
        .WithTags("products")
        .WithName("UpdateProduct")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/{id}", async  (int id, ProductDbContext db) =>
        {
            var affected = await db.Product
                                   .Where(model => model.Id == id)
                                   .ExecuteDeleteAsync();

            return affected == 1 ? Results.Ok() : Results.NotFound();
        })
        .WithTags("products")
        .WithName("DeleteProduct")
        .Produces<Product>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
