namespace Select_HtmlToPdf_NetCore
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppOptions>(configuration.GetRequiredSection("app"));
            services.Configure<PostgresOptions>(configuration.GetRequiredSection("postgres"));
            services.Configure<RabbitmqOptions>(configuration.GetRequiredSection("rabbitmq"));
            return services;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetRequiredSection(sectionName);
            section.Bind(options);

            return options;
        }
    }

    
}