using Demo.Dal.DemoDbContext;
using Demo.Dal.Interface;
using Demo.Dal.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Builder configuration

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            //builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion

            //db context is registered as scoped by default
            builder.Services.AddDbContext<DemoDbContext>(opt =>
            {
                var dbProvider = builder.Configuration["DbProvider"];
                switch (dbProvider)
                {
                    case "oracle":
                        {
                            opt.UseOracle(builder.Configuration.GetConnectionString("OracleDemoDbContext"));
                            break;
                        }
                    case "mssql":
                        {
                            opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLDemoDbContext"));
                            break;
                        }
                    default:
                        {
                            throw new Exception("Not supported DB provider");
                        }
                }
            });

            builder.Services.AddScoped<IToolService, ToolService>();
            var app = builder.Build();
            
            #region Configure swagger

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #endregion

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DemoDbContext>();

                DbInitializer.Initialize(context);

                #region Capture SQL script if needed

                //To get the SQL used by EnsureCreated, you can use the GenerateCreateScript method.
                var sql = context.Database.GenerateCreateScript();
                File.WriteAllText($"create_{builder.Configuration["DbProvider"]}.sql", sql);

                #endregion
            }

            #region Middlewares configuration

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}