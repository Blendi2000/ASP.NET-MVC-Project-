using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GymWebApplication1.Areas.Identity.IdentityHostingStartup))]
namespace GymWebApplication1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}