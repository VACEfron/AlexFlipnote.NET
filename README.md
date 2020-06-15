# AlexFlipnote.NET
 🍃 An API wrapper for AlexFlipnote's web API.
 
## Installation
https://www.nuget.org/packages/AlexFlipnote.NET/

## Example
Example command using [Discord.NET](https://github.com/discord-net/Discord.Net) and AlexFlipnote.NET.
```csharp
[Command("captcha"), Summary("Create your custom captcha.")]
public async Task Captcha([Remainder]string MyText)
{
    var stream = AlexEndpoints.Captcha(MyText);
    await Context.Channel.SendFileAsync(stream, "image.png");
}
```

## AlexFlipnote's API
https://api.alexflipnote.dev/
