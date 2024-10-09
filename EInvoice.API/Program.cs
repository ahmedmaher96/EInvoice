
using EInvoice.API.Helpers;
using EInvoice.BLL.Handlers;
using EInvoice.BLL.Interfaces.IGeneric;
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
            builder.Services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepositries<>));
            builder.Services.AddScoped(typeof(IGenericHandler<,>), typeof(GenericHandler<,>));
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
