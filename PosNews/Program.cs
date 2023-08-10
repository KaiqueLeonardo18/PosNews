using Infraestrutura.Contextes;
using Infraestrutura.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PosNews.Interfaces;
using PosNews.Mapping;
using PosNews.Repository;
using PosNews.Services;
using PosNews.Services.Interfaces;

namespace PosNews
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection"));
            });

            builder.Services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AuthSqlConnection"));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();

            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme =
            //})

            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<INoticiaRepository, NoticiaRepository>();
            builder.Services.AddAutoMapper(typeof(MappingConfig));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}