using Microsoft.Identity.Client;
using RestTestProject.Services.Interfaces;

namespace RestTestProject.Services
{
    public class PublicClient : IPublicClient
    {
        public PublicClientApplication client { get; set; }

        /// <summary>
        /// Instanciates the PublicClient class, creates and configures the client.
        /// </summary>
        public PublicClient()
        {
            PublicClientApplicationOptions config = ReadConfigFromJsonFile("appsettings.json");
            this.client = (PublicClientApplication) PublicClientApplicationBuilder.CreateWithApplicationOptions(config)
                       .Build();
        }

        public PublicClientApplicationOptions ReadConfigFromJsonFile(string path)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path);
            IConfigurationRoot Configuration = builder.Build();

            PublicClientApplicationOptions config = new PublicClientApplicationOptions();

            Configuration.Bind("AppRegistrationAuth", config);
            return config;
        }
    }
}
