var builder = DistributedApplication.CreateBuilder(args);

var productsdb = builder.AddPostgres("pg-products")
                        .WithPgAdmin()
                        .AddDatabase("productsdb");

var storeinfodb = builder.AddPostgres("pg-storeinfo")
                         .WithPgAdmin()
                         .AddDatabase("storeinfodb");

var redis = builder.AddRedis("redis");

var products = builder.AddProject<Projects.eShopLite_Products>("eshoplite-products")
                      .WithReference(productsdb)
                      .WaitFor(productsdb);

var storeinfo = builder.AddProject<Projects.eShopLite_StoreInfo>("eshoplite-storeinfo")
                       .WithReference(storeinfodb)
                       .WaitFor(storeinfodb);

builder.AddProject<Projects.eShopLite_Store>("eshoplite-store")
       .WithExternalHttpEndpoints()
       .WithReference(products)
       .WithReference(storeinfo)
       .WithReference(redis)
       .WaitFor(products)
       .WaitFor(storeinfo)
       .WaitFor(redis);

builder.Build().Run();
