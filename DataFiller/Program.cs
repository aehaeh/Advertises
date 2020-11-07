using System;
using System.IO;
using System.Text;
using Advertises.Models;
using DataFiller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataFiller2
{
    class Program
    {
//        public IConfiguration Configuration { get; }
        public static IConfigurationRoot Configuration;
        public static IServiceProvider ServiceProvider;
        public static ILoggerFactory LoggerFactory;
        public ApplicationDbContext _context;        
    
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;            

            var services = new ServiceCollection();

/*

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Samfa")));

*/

            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    "Server=.;Database=Advertises;Trusted_Connection=True;MultipleActiveResultSets=true;connect timeout=150;", b => b.MigrationsAssembly("Samfa")));


            
            
            ConfigureServices(services);


            /*services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });*/

            ServiceProvider = services.BuildServiceProvider();

            ServiceProvider.GetService<App>().Run().Wait();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {

            // add services
//            serviceCollection.AddTransient<App>();

            // add app
            serviceCollection.AddTransient<App>();
        }       
    }
}
