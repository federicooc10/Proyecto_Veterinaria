using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones
            services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
            services.AddScoped<IFormulas_MedicamentosPresentacion, Formulas_MedicamentosPresentacion>();
            services.AddScoped<IFormulasPresentacion, FormulasPresentacion>();
            services.AddScoped<IHistoriales_ClinicosPresentacion, Historiales_ClinicosPresentacion>();
            services.AddScoped<IMascotasPresentacion, MascotasPresentacion>();
            services.AddScoped<IMedicamentosPresentacion, MedicamentosPresentacion>();
            services.AddScoped<IRazasPresentacion, RazasPresentacion>();
            services.AddScoped<IVeterinariosPresentacion, VeterinariosPresentacion>();
            services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}