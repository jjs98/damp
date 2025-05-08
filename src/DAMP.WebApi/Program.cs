using FastEndpoints;
using FastEndpoints.Swagger;

namespace DAMP.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddFastEndpoints();
        builder.Services.SwaggerDocument();

        var app = builder.Build();

        app.UseFastEndpoints();
        app.UseSwaggerGen();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}
