using BlazorAppWithMediatrAndDapper.BLL;
using BlazorAppWithMediatrAndDapper.DAL.Repositories;
using BlazorAppWithMediatrAndDapper.PLL.Client;
using BlazorAppWithMediatrAndDapper.PLL.Components;
using System.Reflection;

namespace BlazorAppWithMediatrAndDapper.PLL;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddRazorComponents()
			.AddInteractiveServerComponents()
			.AddInteractiveWebAssemblyComponents();
		builder.Services.AddControllers();
		builder.Services.AddTransient<IProviderRepository, ProviderRepository>();
		builder.Services.AddTransient<OrderRepository>();
		builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
		builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<EntryPointBLL>());

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseWebAssemblyDebugging();
		}
		else
		{
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();

		app.UseStaticFiles();
		app.UseRouting();
		app.UseAntiforgery();

		app.MapRazorComponents<App>()
			.AddInteractiveServerRenderMode()
			.AddInteractiveWebAssemblyRenderMode()
			.AddAdditionalAssemblies(typeof(EntryPointClientPPL).Assembly);
		app.MapControllers();

		app.Run();
	}
}
