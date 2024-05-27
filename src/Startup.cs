using Microsoft.EntityFrameworkCore;
using TTDL_Backend.Services;
using TTDL_Backend.Tests.Services;

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
            services.AddSwaggerGen();

            // Conditionally add the service or the test service
            if (Configuration.GetValue<bool>("testing"))
            {
                services.AddScoped<IUserservice, Testuserservice>();
            }

            else
            {
                services.AddScoped<IUserservice, Userservice>();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
                    dbContext.Database.Migrate(); // Apply any pending migrations
                    dbContext.SeedData(); // Seed initial data
                }
            }

            catch(Exception ex)
            {
                System.Console.WriteLine($"Problem seeding/creating db: {ex}");
            }
        }
    }
}
