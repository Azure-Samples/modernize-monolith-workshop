var builder = DistributedApplication.CreateBuilder(args);

var products = builder.AddProject<Projects.eShopLite_Products>("eshoplite-products");

var storeinfo = builder.AddProject<Projects.eShopLite_StoreInfo>("eshoplite-storeinfo");

builder.AddProject<Projects.eShopLite_Store>("eshoplite-store")
       .WithReference(products)
       .WithReference(storeinfo)
       .WaitFor(products)
       .WaitFor(storeinfo);

builder.Build().Run();
