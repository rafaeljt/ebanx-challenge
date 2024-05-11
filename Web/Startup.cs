using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Web
{
    public class Startup
    {
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