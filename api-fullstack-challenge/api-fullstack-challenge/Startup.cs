using api_fullstack_challenge.Repository;
using api_fullstack_challenge.Repository.Interface;
using api_fullstack_challenge.Repository.Repository.Implementation;
using api_fullstack_challenge.Repository.Repository.Interface;
using api_fullstack_challenge.Services.Implementation;
using api_fullstack_challenge.Services.Interface;
using api_fullstack_challenge.Services.Services.Scheduler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace api_fullstack_challenge
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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogsErrorRepository, LogErrorRepository>();
            services.AddScoped<IWebScrapingService, WebScrapingService>();

            var ConnectionString = Configuration.GetConnectionString("Database");
            var Connection = new MongoClient(ConnectionString);
            var DatabaseName = Configuration.GetConnectionString("DatabaseName");

            ContextMongo.Database = Connection.GetDatabase(DatabaseName);

            Scheduler.Schedule();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                                builder => builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api_fullstack_challenge", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api_fullstack_challenge v1"));
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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
