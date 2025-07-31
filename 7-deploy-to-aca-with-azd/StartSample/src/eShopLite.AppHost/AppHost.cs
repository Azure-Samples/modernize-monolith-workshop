var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");

var products = builder.AddProject<Projects.eShopLite_Products>("eshoplite-products");

var storeinfo = builder.AddProject<Projects.eShopLite_StoreInfo>("eshoplite-storeinfo");

builder.AddProject<Projects.eShopLite_Store>("eshoplite-store")
       .WithReference(products)
       .WithReference(storeinfo)
       .WithReference(redis)
       .WaitFor(products)
       .WaitFor(storeinfo)
       .WaitFor(redis);

builder.Build().Run();
