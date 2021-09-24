using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TrainingWebApp.Data;
using TrainingWebApp.Repo;
using TrainingWebApp.IRepo;
using EFCore.DbContextFactory.Extensions;
using NPOI.SS.Formula.Functions;

namespace TrainingWebApp
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
            //var dbLogger = LoggerFactory.Create(builder => builder.AddConsole());

            var ConnString = Configuration.GetConnectionString("Default");
            services.AddAutoMapper(typeof(Startup));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnString));
            services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(ConnString),
             ServiceLifetime.Scoped);
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPostRepo, PostRepo>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrainingWebApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrainingWebApp v1"));
            }

            //app.Use(async (context, next) =>
            //{
            //    try { await next(); }
            //    catch { await context.Response.WriteAsync("Hello World From 1st Middleware!"); }
   
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World From 2nd Middleware");
            //    throw new Exception("error");
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}
