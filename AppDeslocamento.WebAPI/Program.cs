using AppDeslocamento.Data.Context;
using AppDeslocamento.Data.Repository;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppDeslocamento.WebAPI
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(opt => {
                opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("AppDbContext"),
                    b => b.MigrationsAssembly("AppDeslocamento.Data"));
            });

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var appAssembly = typeof(
                Application.Clientes.CadastrarClienteCommand)
                .Assembly;
             
            builder.Services.AddMediatR(appAssembly);

            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}