
using EInvoice.API.Helpers;
using EInvoice.BLL.Handlers;
using EInvoice.BLL.Interfaces;
using EInvoice.BLL.Interfaces.IGeneric;
using EInvoice.BLL.Repositries;
using EInvoice.BLL.Repositries.Generic;
using EInvoice.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EInvoice.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services Container
            // Add services to the container.
            builder.Services.AddDbContext<EInvoiceDBContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //builder.Services.AddControllers()
            //                .AddJsonOptions(options =>
            //                {
            //                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //                    options.JsonSerializerOptions.MaxDepth = 64;
            //                });
            builder.Services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepositries<>));
            builder.Services.AddScoped(typeof(IGenericHandler<,>), typeof(GenericHandler<,>));
            builder.Services.AddScoped<IInvoiceRepositry, InvoiceRepositry>();
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); 
            #endregion

            var app = builder.Build();

            #region Update-Database

            var Scope = app.Services.CreateScope();
            var Service = Scope.ServiceProvider;
            var DbContext = Service.GetRequiredService<EInvoiceDBContext>();
            await DbContext.Database.MigrateAsync();
            Scope.Dispose();

            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
