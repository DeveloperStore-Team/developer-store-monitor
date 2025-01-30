using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using SalesEventConsumer.Hubs;
using SalesEventConsumer.Consumers;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.Services.AddMassTransit(config =>
{
    config.SetKebabCaseEndpointNameFormatter();


    config.UsingRabbitMq((ctx, cfg) =>
    {
        var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";

        cfg.Host($"rabbitmq://{rabbitMqHost}", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("sale-created-queue", e =>
        {
            e.ConfigureConsumer<SaleCreatedConsumer>(ctx);
        });

        cfg.ReceiveEndpoint("sale-modified-queue", e =>
        {
            e.ConfigureConsumer<SaleModifiedConsumer>(ctx);
        });

        cfg.ReceiveEndpoint("sale-canceled-queue", e =>
        {
            e.ConfigureConsumer<SaleCanceledConsumer>(ctx);
        });

        cfg.ReceiveEndpoint("item-canceled-queue", e =>
        {
            e.ConfigureConsumer<ItemCanceledConsumer>(ctx);
        });
    });
    
    config.AddConsumer<SaleCreatedConsumer>();
    config.AddConsumer<SaleModifiedConsumer>();
    config.AddConsumer<SaleCanceledConsumer>();
    config.AddConsumer<ItemCanceledConsumer>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
      builder => builder
          .WithOrigins("http://localhost:3000")
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials());

    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true));
});


builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
app.UseCors("CorsPolicy");
app.MapHub<SalesHub>("/salesHub");

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Sales Event Consumer Started and Listening for Events!");

app.Run();
