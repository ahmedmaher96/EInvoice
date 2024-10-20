using EInvoice.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace EInvoice.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5173") });
            builder.Services.AddTransient<GeneralService>();
            builder.Services.AddTransient<InvoiceService>();
            await builder.Build().RunAsync();
        }
    }
}
