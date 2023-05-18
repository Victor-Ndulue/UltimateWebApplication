namespace UltimateWebApplication.Extensions
{
    public static class ServiceExtensions
    {
        //CORS Configuration
        public static void ConfigureCors (this IServiceCollection services)=>
            services.AddCors (options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    //This allows request from all source, in real life dev project
                    //.WithOrigins("htpps://linkname.com") is used, granting access to only referenced.
                    builder.AllowAnyOrigin(); 
                    builder.AllowAnyMethod();//==> .WithMethods("Post", "Get")
                    builder.AllowAnyHeader(); //==> .WithHeaders("accept","content-type")
                });
            });

        // IIS Configuration
        public static void ConfigureIIsIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
                //Initialize properties if you desire
            });
    }
}
