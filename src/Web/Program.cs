using Infrastructure;
using JJS.Cache;
using MudBlazor.Services;
using Web.Components;
using Web.Services;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder
            .Services.RegisterInfrastructureModule(builder.Configuration)
            .AddScoped<TitleService>()
            .UseCacheService(builder.Configuration)
            .AddMudServices()
            .AddRazorComponents()
            .AddInteractiveServerComponents();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

        app.Run();
    }
}
