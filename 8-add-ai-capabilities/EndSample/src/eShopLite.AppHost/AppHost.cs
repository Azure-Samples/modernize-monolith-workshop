var builder = DistributedApplication.CreateBuilder(args);

// Add GitHub token parameter for AI chatbot
var githubToken = builder.AddParameter("github-token", secret: true);

var products = builder.AddProject<Projects.eShopLite_Products>("eshoplite-products");

var storeinfo = builder.AddProject<Projects.eShopLite_StoreInfo>("eshoplite-storeinfo");

builder.AddProject<Projects.eShopLite_Store>("eshoplite-store")
       .WithReference(products)
       .WithReference(storeinfo)
       .WithEnvironment("GITHUB_TOKEN", githubToken)
       .WaitFor(products)
       .WaitFor(storeinfo);

builder.Build().Run();
