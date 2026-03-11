using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Varelager_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

var postgres = builder.AddPostgres("db");

builder.AddProject<Projects.Varelager_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WithReference(postgres)
    .WaitFor(apiService);

builder.Build().Run();