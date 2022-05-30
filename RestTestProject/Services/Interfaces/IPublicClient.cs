using Microsoft.Identity.Client;

namespace RestTestProject.Services.Interfaces
{
    public interface IPublicClient
    {
        /// <summary>
        /// Gets - Sets the client
        /// </summary>
        public PublicClientApplication client { get; set; }

        /// <summary>
        /// Reads the configuration from a json file
        /// </summary>
        /// <param name="path">Path to the configuration json file</param>
        /// <returns>SampleConfiguration as read from the json file</returns>
        public PublicClientApplicationOptions ReadConfigFromJsonFile(string path);
    }
}
