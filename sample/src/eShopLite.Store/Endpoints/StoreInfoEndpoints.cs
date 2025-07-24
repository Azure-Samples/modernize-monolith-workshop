using eShopLite.Store.DataEntities;
using eShopLite.Store.StoreInfoData;

using Microsoft.EntityFrameworkCore;

namespace eShopLite.Store.Endpoints;

public static class StoreInfoEndpoints
{
    public static void MapStoreInfoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/storeinfo");

        group.MapGet("/", async (StoreInfoDbContext db) =>
        {
            return await db.Store.ToListAsync();
        })
        .WithTags("storeinfo")
        .WithName("GetStoreInfo")
        .Produces<List<StoreInfo>>(StatusCodes.Status200OK);


        group.MapPost("/", async (StoreInfo storeInfo, StoreInfoDbContext db) =>
        {
            db.Store.Add(storeInfo);
            await db.SaveChangesAsync();
            return Results.Created($"/api/storeinfo/{storeInfo.Id}", storeInfo);
        })
        .WithTags("storeinfo")
        .WithName("CreateStoreInfo")
        .Produces<StoreInfo>(StatusCodes.Status201Created);

        group.MapGet("/{id}", async (int id, StoreInfoDbContext db) =>
        {
            var storeInfo = await db.Store
                                    .AsNoTracking()
                                    .SingleOrDefaultAsync(model => model.Id == id);
            return storeInfo is StoreInfo model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithTags("storeinfo")
        .WithName("GetStoreInfoById")
        .Produces<StoreInfo>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (int id, StoreInfo storeInfo, StoreInfoDbContext db) =>
        {
            var affected = await db.Store
                                   .Where(model => model.Id == id)
                                   .ExecuteUpdateAsync(setters => setters
                                       .SetProperty(m => m.Id, storeInfo.Id)
                                       .SetProperty(m => m.Name, storeInfo.Name)
                                       .SetProperty(m => m.City, storeInfo.City)
                                       .SetProperty(m => m.State, storeInfo.State)
                                       .SetProperty(m => m.Hours, storeInfo.Hours)
                                   );
            return affected == 1 ? Results.Ok() : Results.NotFound();
        })
        .WithTags("storeinfo")
        .WithName("UpdateStoreInfo")
        .Produces(StatusCodes.Status200OK);
    }
}
