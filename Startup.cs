using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProvaPub.Repository;
using ProvaPub.Repository.Interfaces;
using ProvaPub.Services;

namespace ProvaPub
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
            services.AddControllersWithViews();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<TestDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();



        }

    }
}
