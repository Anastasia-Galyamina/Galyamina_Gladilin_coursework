using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using BankDataBaseImplement.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankRestApi
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<IMoneyLogic, MoneyLogic>();       
            services.AddTransient<IStorageMoneyLogic, StorageMoneyLogic>();
            services.AddTransient<ICreditLogic, CreditLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IDealLogic, DealLogic>();
            services.AddTransient<MainLogic>();
            services.AddTransient<ReportLogic>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
