using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Dev.App.Data;

namespace Dev.App
{
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
      services.AddControllersWithViews();

      services.Configure<RazorViewEngineOptions>(options =>
      {
        options.AreaViewLocationFormats.Clear();
        options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
        options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
        options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
      });

      services.AddTransient<IPedidoRepository, PedidoRepository>();
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
      }
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapAreaControllerRoute(
            name: "AreaProdutos",
            areaName: "Produtos",
            pattern: "Produtos/{controller=Cadastro}/{action=Index}/{id?}"
        );

        endpoints.MapAreaControllerRoute(
            name: "AreaVendas",
            areaName: "Vendas",
            pattern: "Vendas/{controller=Pedidos}/{action=Index}/{id?}"
        );

        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
      });
    }
  }
}
