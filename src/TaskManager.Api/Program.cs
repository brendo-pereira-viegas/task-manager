WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseOpenApi();
app.Run();