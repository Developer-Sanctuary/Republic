var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.Republic_ApiService>("apiservice");

builder.AddProject<Projects.Republic_Web>("webfrontend")
	.WithExternalHttpEndpoints()
	.WithReference(cache)
	.WithReference(apiService);

builder.AddProject<Projects.Republic_Judiciary>("court")
	.WithReference(cache)
	.WithReference(apiService);

builder.Build().Run();
