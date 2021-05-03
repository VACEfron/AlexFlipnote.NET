# 🍃 AlexFlipnote.NET
An API wrapper for AlexFlipnote's web API.

## Installation
https://www.nuget.org/packages/AlexFlipnote.NET/

## Example
Example command using [Discord.NET](https://github.com/discord-net/Discord.Net) and AlexFlipnote.NET.
```csharp
[Command("captcha"), Summary("Create your custom captcha.")]
public async Task Captcha([Remainder]string myText)
{
    // Create an instance of the AlexFlipnoteClient class and pass your token to the constructor.
    var client = new AlexFlipnoteClient("yourToken");
    
    // Invoke the Captcha method.
    var stream = await client.Captcha(myText); 

    await Context.Channel.SendFileAsync(stream, "image.png");
}
```

## AlexFlipnote's API
https://api.alexflipnote.dev/

## Discord
Me: VAC Efron#0001

My server: https://discord.gg/xJ2HRxZ

AlexFlipnote: https://discord.gg/DpxkY3x
