using Lanches.Context;
using Lanches.Models;
using Lanches.Repositorio;
using Lanches.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace LanchesMac;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => 
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddControllersWithViews();

        services.AddMemoryCache();
        services.AddSession();

        services.AddTransient<ILancheRepositorio, LancheRepositorio>();
        services.AddTransient<ICategoriasRepositorio, CategoriaRepositorio>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //Usamos o AddScoped pois a cada requisição nova
        //vai ser gerado um carrinho novo, portanto
        // se dois clientes acessarem ao mesmo tempo cada um
        // tera seu próprio carrinho.
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.UseSession();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}