# APIInteractiveTokenAcquisition
Implemented scenario where REST API has an endpoint to interactively sign in users and acquire an access token for the API itself.

## About the Access Token
The scenario to acquire the token is based on the [Desktop app that calls web APIs](https://docs.microsoft.com/en-us/azure/active-directory/develop/scenario-desktop-overview).

When a user does a token request, a new [Access Token](https://docs.microsoft.com/en-us/azure/active-directory/develop/access-tokens) JWT V1.0 is issued every time, that means the user also need to reauthenticate everytime the request is done, the expiration time for each is between 60 to 90 minutes. No refresh tokens are involved in the process.

## Requirements:
[Visual Studio](https://visualstudio.microsoft.com/ "Visual Studio")
[.Net 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0 ".Net 6.0")

## How to run this solution:

### Configuration
NOTE: In this guide, we are going to specifically configure the solution to be acccessed only by **Accounts inside the organization** using a **public client** with [MSAL library](https://docs.microsoft.com/en-us/azure/active-directory/develop/microsoft-identity-web "MSAL library").

1. Register the solution on your Azure Acccount following the steps in [this page](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app#register-an-application "this page")  and select the option for **Accounts in any organizational directory**, once the registration is complete, inside the application registration:
	- Add a new **Mobile and desktop applications** platform on the Authentication section, and ensure to check the MSAL URI (this solution is using this library to authenticate) and the custom redirect URI for the .NET application, which is `http://localhost` learn more [here](https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-net-instantiate-public-client-config-options "here").
  ![image](https://user-images.githubusercontent.com/19196644/171053160-c3db5f5c-05fc-46c0-9b4f-e4cece0a6243.png)
	
  	- Set the **Application ID URI** and **at least one scope** to be able to request access.
  ![image](https://user-images.githubusercontent.com/19196644/171053393-6ca4c019-0f1f-49c5-890a-6ff2ad641127.png)

2. Load this solution on visual studio code, here is a [tutorial](https://docs.microsoft.com/en-us/visualstudio/get-started/tutorial-open-project-from-repo?view=vs-2022 "tutorial").

3. Open the `appsettings.json` file, and fill the blank strings with information specific to your azure account:
	- **AzureAd section:** azure active directory properties, more information about [here](https://docs.microsoft.com/en-us/dotnet/api/microsoft.identity.web.microsoftidentitywebapiauthenticationbuilderextensions.addmicrosoftidentitywebapi?view=azure-dotnet "here")
	- **AppRegistrationAuth section:** application registration properties, more information about [here](https://docs.microsoft.com/en-us/dotnet/api/microsoft.identity.client.publicclientapplicationoptions?view=azure-dotnet "here").
	- **AppRegistrationAuth section:** application registration scopes that you registered, each string eleent represents one scope, remember to register at least one.

### Start the application
Start the application on visual studio clicking the run button, a new browser page will open inside the swagger documentation:

![image](https://user-images.githubusercontent.com/19196644/171053593-bbaab56f-b38e-41c8-8a7a-e12aa657b5fb.png)

- `/Auth`: will follow the [Desktop and mobile app sign-in flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/app-sign-in-flow#desktop-and-mobile-app-sign-in-flow).

- `/Sample`: will respond with a simple messasge if user is using a valid token, otherwise will return a 401 unauthorized.
