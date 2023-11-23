using Challenge.Common.Exceptions.Exceptions;
using Challenge.Common.Exceptions.Helpers;
using Challenge.Common.IoC.Config;
using Challenge.Common.Mappers.Profiless;
using Challenge.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

namespace Challenge.Presentation.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });

            services.AddDbContextPool<ChallengeContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Challenge"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
            });

            services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfileModelEvent));

            ////Configure ID
            services.InjectionDependecy_Repository();
            services.InjectionDependecy_Services();
            services.InjectionDependecy_ExceptionHandler();  
            services.InjectionDependecy_Validation();
            services.InjectionDependecy_ResultMessage(Configuration);
            services.AddCors(
                options => options.AddPolicy("AllowCors",
                builder =>
                {
                    builder
                    .WithOrigins(
                        "http://localhost:4200" 
                        )
                    .AllowAnyOrigin() 
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                })
            );

            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Commissions.Api", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Challenge API",
                    Version = "v1",
                    Description = "An API to perform Challenge"
                });
                c.ResolveConflictingActions(x => x.First());
                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILog logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Commissions.Api v1"));
            }


            app.ConfigureExceptionHandler(logger);
            //app.UseStatusCodePages();
            app.UseCors("AllowCors");

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
 