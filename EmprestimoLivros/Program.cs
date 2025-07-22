using DotNetEnv;
using EmprestimoLivros.Context;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Carrega as variáveis do .env
            Env.Load(); // ← carrega o arquivo .env na inicialização

            // Adiciona variáveis de ambiente à configuração
            builder.Configuration.AddEnvironmentVariables();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure database context
            //Verificar se tem essa variável
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}