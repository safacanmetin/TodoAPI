namespace TodoAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Service registrations (not covered here)
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 1. Enable CORS
            app.UseCors(options => options
                .AllowAnyOrigin() // Allow requests from all origins (adjust for production)
                .AllowAnyMethod()
                .AllowAnyHeader());

            // 2. Use Routing
            app.UseRouting();

            // 3. Configure Endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
