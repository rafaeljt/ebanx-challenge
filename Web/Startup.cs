using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();
            
            services.AddTransient<IBalanceService, BalanceService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IResetService, ResetService>();
            
            //in-mem persistence
            services.AddSingleton<IAccountService, AccountService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}