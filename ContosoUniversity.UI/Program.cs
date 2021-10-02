using ContosoUniversity.UI.Services.Base;
using ContosoUniversity.UI.Services.Student;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });
            builder.Services.AddHttpClient<IBaseClient, BaseClient>(_ =>
                new BaseClient(
                    "https://localhost:5001",
                    new HttpClient
                    {
                        BaseAddress = new Uri("https://localhost:5001")
                    }
                )
             );
            builder.Services.AddSingleton<StudentService>();

            await builder.Build().RunAsync();
        }
    }
}
