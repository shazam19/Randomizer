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
