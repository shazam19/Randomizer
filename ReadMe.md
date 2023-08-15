[![Netlify Status](https://api.netlify.com/api/v1/badges/170e8338-7019-4c00-9226-9b7209854d35/deploy-status)](https://app.netlify.com/sites/boisterous-fairy-8822fd/deploys)

## Randomizer

Fun blazor app, to get a random name from a list



### Tech

- Parent code base as code behind
	- Overridden method for customized animation
	
- Single viewmodel for multiple view

- Third-party animation library: https://animate.style/
	- added to index.html
	- needed hard refresh (ctrl+f5)
	
- Scoped css file

- Use of custom event handler: 
	- https://www.meziantou.net/removing-elements-after-an-animation-in-blazor.htm
	- https://docs.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-6.0
		- Wire up the custom event with the event arguments by adding an EventHandlerAttribute attribute annotation for the custom event. The class doesn't require members. Note that the class must be called EventHandlers in order to be found by the Razor compiler, but you should put it in a namespace specific to your app:
		- [EventHandler("oncustomevent", typeof(CustomEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
		static class EventHandlers
		{
		}
	- Use of `onanimationend` event to check animation end
		
- Use of razor component
	- Use of call back option
	- Use of animation
	- Animation belongs the card itself, so if we need to change it's animation we won't have to modify any other file.

- 

--- identity service doc ---
- https://medium.com/nerd-for-tech/authentication-and-authorization-in-net-core-web-api-using-jwt-token-and-swagger-ui-cc8d05aef03c



--- deployed to without domain & ci/cd: 
- netlify
	- publish site (manual)
		- published 'client' to 'local folder'
		- drag/drop or select wwwroot folder in [Deploys](https://app.netlify.com/sites/boisterous-fairy-8822fd/deploys)
	- ci/cd git integration
		- already has all .net tools installed
		- build command: dotnet publish -c Release -o release
		- Publish directory: release/wwwroot
		- add netlify configuration file for proper routing
		- https://swimburger.net/blog/dotnet/how-to-deploy-blazor-webassembly-to-netlify
	- https://boisterous-fairy-8822fd.netlify.app/
	- user: bl@y

- github
	- settings
		- pages (doesn't work, just for static files? the artifact just contains the code)
			- deploy from a branch (currently just shows the readme.md file)
			- https://shazam19.github.io/Randomizer/ (currently just shows the readme.md file)


