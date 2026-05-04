namespace TaskManager.Api.Extensions;

internal static class WebApplicationExtensions
{
    internal static WebApplication UseOpenApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        return app;
    }
}