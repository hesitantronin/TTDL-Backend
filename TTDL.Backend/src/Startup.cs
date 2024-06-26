using Microsoft.EntityFrameworkCore;
using TTDL_Backend.Services;
using Microsoft.OpenApi.Models;
using TTDL_Backend.Repositories;

namespace TTDL_Backend
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
            services.AddDbContext<T_DbContext>(options =>
                        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                options => {
                    options.SwaggerDoc("v1", new OpenApiInfo{
                        Version = "v1",
                        Title="Teckel Teun's Datalab API",
                        Description="De API die gebruikt wordt door de frontend en (upcoming) de embedded."
                    });
                }
            );

            services.AddScoped<IUserservice, Userservice>();
            services.AddScoped<IMeasurementService, MeasurementService>();
            services.AddScoped<IChairService, ChairService>();
            services.AddScoped<IPatientService, PatientService>();

            // Register repositories

            services.AddScoped<IChairRepository, ChairRepository>();

            // Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || 1 == 1) // Temp always show swagger, should be disabked in production
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TTDL_API"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Enable CORS
            app.UseCors("AllowOrigin");

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Apply migrations/initialize db when starting application
            try
            {
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetRequiredService<T_DbContext>();
                    dbContext.Database.Migrate(); // Apply any pending migrations to the database

                    // Seedv mock data for development
                    dbContext.SeedData("/app/DataSources/CHAIR_MOCK_DATA.csv", "/app/DataSources/PATIENT_MOCK_DATA.csv"); // Seed initial (mock) data
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Problem seeding/creating db: {ex}");
            }
        }
    }
}