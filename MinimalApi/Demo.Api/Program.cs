using Demo.Dal.DemoDbContext;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api
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
            
            //db context is registered as scoped by default
            builder.Services.AddDbContext<DemoDbContext>(options => 
            {
                var dbProvider = builder.Configuration["DbProvider"];
                switch(dbProvider)
                {
                    case "oracle":
                        {
                            options.UseLazyLoadingProxies().UseOracle(builder.Configuration.GetConnectionString("OracleDemoDbContext"));
                            break;
                        }
                    case "mssql":
                        {
                            options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("MSSQLDemoDbContext"));
                            break;
                        }
                    default:
                        {
                            throw new Exception("Not supported DB provider");
                        }
                }
            });
        
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<DemoDbContext>();
                context.Database.EnsureCreated();
                //DbInitializer.Initialize(context);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}