# ASP.Net Web API 2 Example
- An example of (.Net Framework 4.5+) ASP.Net Web API 2 application with minimal package dependencies
- Based on the following article: [link](https://thompsonhomero.wordpress.com/2015/01/21/creating-a-clean-web-api-2-project-with-external-authentication/)
- Uses the part 2 of the article to implement Google OAuth 2.0 authentication: [link](https://thompsonhomero.wordpress.com/2015/01/21/creating-a-clean-web-api-2-project-with-external-authentication-part-2/)
- Also added Autofac (for dependency injection) and NLog (for logging) integration logic

## Google auth example
- Uses the Google OAuth 2.0 authentication
- This requires a `web application` project to be created in [Google Cloud Console](https://console.cloud.google.com), in the `APIs & Services` -> `Credentials` dashboard, as an `OAuth client ID` entry
- Auth logic expects two `web.config` variables to be set:
  - `GoogleClientId` - this is the Google `client ID`
  - `GoogleClientSecret` - this is the Google `client secret`
- Additionally, a redirect URI in the format of `http://localhost:port` was set in the Google Cloud Console to enable redirects on successful auth challenge when testing locally