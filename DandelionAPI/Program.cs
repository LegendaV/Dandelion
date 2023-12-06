using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Microsoft.EntityFrameworkCore;

namespace DandelionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/login");
            builder.Services.AddAuthorization();
          
            builder.Services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseNpgsql("Host=localhost;port=5432;Database=test_db;Username=root;Password=root");
            });

            builder.Services.AddScoped<Repo, Repo>();

            var database = builder.Configuration.GetConnectionString("WebApiDatabase");
          
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

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