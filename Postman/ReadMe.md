This folder contains simple postman collections that can be used to first authenticate with Trimble Identity v4 and then perform work within ProjectSight.

The collection ProjectSight API-X.postman_collection contains a set of variables in the collection itself that are used to retrieve an access token and configure the API request.

After the collection is imported edit the collection, switch to the Variables tab and, in the Current Value column, enter the following information from the api.trimblepaas.com GET KEY popup dialog:

* ConsumerKey - Consumer Key
* ConsumerSecret - Consumer Secret
* ApplicationName - Application Name
* PackageAndUsagePlanKey - Package & Usage Plan Key

Click the Update button to update the current values.

Edit the collection again and on the Authorization tab, press the Get New Access Token button.

Once the access token has been generated, press the Proceed button (or wait until the Token Details screen is displayed).

On the Token Details screen press the Use Token button.

Press the Update button to close the edit dialog.

Within the collection, open the Portfolios request.

Click the Send button and the list of Portfolios that you have access to will appear in the response body at the bottom.

If you create a new request, ensure the x-api-key is added and set to {{PackageAndUsagePlanKey}}.