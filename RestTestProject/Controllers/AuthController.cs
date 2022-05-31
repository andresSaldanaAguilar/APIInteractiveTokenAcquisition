using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using RestTestProject.Services.Interfaces;
using System.Net.Http.Headers;

namespace RestTestProject.Controllers
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly PublicClientApplication publicClient;
        private readonly List<string> scopes;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="publicClient">singleton instance of public client</param>
        /// <returns>SampleConfiguration as read from the json file</returns>
        public AuthController(ILogger<AuthController> logger, IPublicClient publicClient)
        {
            this.logger = logger;
            this.publicClient = publicClient.client;
            scopes = GetScopes("appsettings.json");
        }

        /// <summary>
        /// Get scopes from aconfiguration file
        /// </summary>
        /// <param name="path">path to config file</param>
        /// <returns>List of scopes</returns>
        private List<string> GetScopes(string path)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path);
            IConfigurationRoot Configuration = builder.Build();

            List<string> scopes = new List<string>();

            Configuration.Bind("AppRegistrationScopes", scopes);
            return scopes;
        }

        /// <summary>
        /// can interactively log in a user to obtain and access token
        /// </summary>
        /// <returns>Acces token for signed in user</returns>
        [HttpGet(Name = "GetToken")]
        public async Task<string> GetToken()
        {
            AuthenticationResult authResult;
            try
            {
                authResult = await publicClient.AcquireTokenInteractive(scopes)
                        .ExecuteAsync()
                        .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                logger.LogError("Error on account authentication:" + e.Message);
                return e.Message;
            }
            logger.LogInformation("Successfull account authentication:" + authResult.Account);
            return authResult.AccessToken;
        }
    }
}