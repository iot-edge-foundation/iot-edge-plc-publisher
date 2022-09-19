namespace PLCPublisher
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Hosting;
    using PLCPublisher.Commands.ListTags;
    using PLCPublisher.Commands.ListUdtTypes;
    using PLCPublisher.Commands.ReadTag;
    using PLCPublisher.Commands.ReadArray;
    using PLCPublisher.Factories;
    using PLCPublisher.Commands.ListPrograms;
    using JUST;

    class Program
    {
        [System.Obsolete]
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        [System.Obsolete]
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(c => c.AddConsole(opts =>
                {
                    opts.TimestampFormat = "yyyy-MM-ddTHH:mm:ss.fffZ ";
                }))
                .ConfigureServices(c => ConfigureServices(c));
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITagFactory, TagFactory>();  

            services.AddTransient<ListTagsCommandHandler>();  
            services.AddTransient<ListUdtTypesCommandHandler>();  
            services.AddTransient<ListProgramsCommandHandler>();
            services.AddTransient<ReadTagCommandHandler>(); 
            services.AddTransient<ReadArrayCommandHandler>();    

            services.AddHostedService<PLCPublisherModule>();
        }
    }
}
