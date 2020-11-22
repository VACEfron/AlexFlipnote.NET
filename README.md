# 🍃 AlexFlipnote.NET
An API wrapper for AlexFlipnote's web API.

## Installation
https://www.nuget.org/packages/AlexFlipnote.NET/

## Example
Before using any endpoints, you must set your auth token. Authorization tokens are required to access this API. You can invoke this method somewhere in your Main function.
```csharp
AlexEndpoint.SetAuthToken("YOUR_TOKEN");
```
Example command using [Discord.NET](https://github.com/discord-net/Discord.Net) and AlexFlipnote.NET.
```csharp
[Command("captcha"), Summary("Create your custom captcha.")]
public async Task Captcha([Remainder]string myText)
{
    // Invoke the Captcha method.
    // All endpoints can be accessed from the AlexEndpoint class.
    var stream = AlexEndpoint.Captcha(myText); 

    await Context.Channel.SendFileAsync(stream, "image.png");
}
```

## AlexFlipnote's API
https://api.alexflipnote.dev/

## Discord
Me: VAC Efron#0001

My server: https://discord.gg/xJ2HRxZ

AlexFlipnote: https://discord.gg/DpxkY3x
