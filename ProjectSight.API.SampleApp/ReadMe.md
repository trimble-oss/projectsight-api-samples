This sample application is used to demonstrate how to authenticate with Trimble Identity v4 and execute API requests against API-X (api.trimblepaas.com).

This will be the primary method of interacting with the ProjectSight API for external consumers until the API external marketplace becomes available.

The user interface supports authenticating with Trimble Identity in two different ways:

* As an application (when the "As User?" checkbox is unchecked).

When connecting as an application, the request to Trimble Identity returns an Application token which can then be passed in the header of the API request.

The API application's client id must be mapped to a specific integration user in ProjectSight by ProjectSight support.

Once this is done, ProjectSight will perform the request operation as that integration user.

* As an end user (when the "As User?" checkbox is checked).

In this scenario, the user is directed initially to the Trimble Identity login page with a specific set of information in the
URL that tells Trimble Identity who is requesting the login and what to do when the login has completed.

This sample application uses Selenium ChromeDriver to simplify the application, but this means that the browser information isn't
usually retained between sessions. There are options to allow this, but none are appropriate for a sample application like this.

Once the user has completed their login, Trimble Identity will return an auth code to the redirect URI.

This auth code is then exchanged for a full user token by calling the authorize endpoint in Trimble Identity.

The token returned by this operation is then used in the header of the API request.

Because the token contains, among other information, the user's Trimble UUID, ProjectSight will then perform the action requested in the API as that user.

