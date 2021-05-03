using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AlexFlipnote.NET
{
    /// <summary>
    /// Class which contains all methods for the endpoints.
    /// </summary>
    public class AlexFlipnoteClient
    {
        public AlexFlipnoteClient(string token)
        {
            Token = token;
        }

        public string Token { get; set; }

        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'achievement unlocked' popup.
        /// </summary>     
        public async Task<MemoryStream> Achievement(string text, Icon icon)
            => await RequestFunctions.ImageRequest($"achievement?text={text}&icon={(icon == Icon.Random ? new Random().Next(1, 45) : (int)icon)}", Token);

        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'achievement unlocked' popup.
        /// </summary>      
        public async Task<MemoryStream> Achievement(string text, int? icon = null)
            => await RequestFunctions.ImageRequest($"achievement?text={text}&icon={(icon is null ? new Random().Next(1, 45) : icon)}", Token);

        /// <summary>
        /// Returns a MemoryStream for your own image over the 'Am I a joke to you?' meme.
        /// </summary>       
        public async Task<MemoryStream> AmIAJoke(string imageUrl)
            => await RequestFunctions.ImageRequest($"amiajoke?image={imageUrl}", Token);

        /// <summary>
        /// Returns a MemoryStream for showing how bad someone is.
        /// </summary>       
        public async Task<MemoryStream> Bad(string imageUrl)
            => await RequestFunctions.ImageRequest($"bad?image={imageUrl}", Token);

        /// <summary>
        /// Returns a url to a random birb image.
        /// </summary>     
        public async Task<string> Birb()
            => await RequestFunctions.JsonRequest("birb", "file", Token);

        /// <summary>
        /// Returns a MemoryStream for your own 'Tom calling' reaction meme.
        /// </summary>       
        public async Task<MemoryStream> Calling(string text)
            => await RequestFunctions.ImageRequest($"calling?text={text}", Token);

        /// <summary>
        /// Returns a MemoryStream for your custom captcha image.
        /// </summary>      
        public async Task<MemoryStream> Captcha(string text)
            => await RequestFunctions.ImageRequest($"captcha?text={text}", Token);

        /// <summary>
        /// Returns a url to a random cat image.
        /// </summary>      
        public async Task<string> Cats()
            => await RequestFunctions.JsonRequest("cats", "file", Token);

        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'challenge completed' popup.
        /// </summary>       
        public async Task<MemoryStream> Challenge(string text, Icon icon)
            => await RequestFunctions.ImageRequest($"challenge?text={text}&icon={(icon == Icon.Random ? new Random().Next(1, 45) : (int)icon)}", Token);

        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'challenge completed' popup.
        /// </summary>    
        public async Task<MemoryStream> Challenge(string text, int? icon = null)
            => await RequestFunctions.ImageRequest($"challenge?text={text}&icon={(icon is null ? new Random().Next(1, 45) : icon)}", Token);

        /// <summary>
        /// Returns an object with all provided color info.
        /// </summary>      
        public async Task<Color> Color(string hex = "random")
        {
            JObject data = await RequestFunctions.JObjectRequest($"color/{(hex == "random" ? string.Format("{0:X6}", new Random().Next(0x1000000)) : hex)}", Token);

            return JsonConvert.DeserializeObject<Color>(data.ToString());
        }

        /// <summary>
        /// Returns a MemoryStream for an image of a color.
        /// </summary>    
        public async Task<MemoryStream> ColorImage(string hex)
            => await RequestFunctions.ImageRequest($"color/image/{hex}", Token);

        /// <summary>
        /// Returns a MemoryStream for a gradient image of a color.
        /// </summary>      
        public async Task<MemoryStream> ColorImageGradient(string hex)
            => await RequestFunctions.ImageRequest($"color/image/gradient/{hex}", Token);

        /// <summary>
        /// Returns a MemoryStream for a colourified image.
        /// </summary>       
        public async Task<MemoryStream> Colourify(string imageUrl, string colorHex = "", string backgroundHex = "")
            => await RequestFunctions.ImageRequest($"colourify?image={imageUrl}{(!string.IsNullOrEmpty(colorHex) ? $"&c={colorHex}" : "")}" +
                $"{(!string.IsNullOrEmpty(backgroundHex) ? $"&b={backgroundHex}" : "")}", Token);

        /// <summary>
        /// Returns a MemoryStream for a fake Google 'did you mean' image.
        /// </summary>    
        public async Task<MemoryStream> DidYouMean(string topText, string bottomText)
            => await RequestFunctions.ImageRequest($"didyoumean?top={topText}&bottom={bottomText}", Token);

        /// <summary>
        /// Returns a url to a random dog image.
        /// </summary>   
        public async Task<string> Dogs()
            => await RequestFunctions.JsonRequest("dogs", "file", Token);

        /// <summary>
        /// Returns a MemoryStream for your own drake meme.
        /// </summary>      
        public async Task<MemoryStream> Drake(string topText, string bottomText)
            => await RequestFunctions.ImageRequest($"drake?top={topText}&bottom={bottomText}", Token);

        /// <summary>
        /// Returns a MemoryStream for your custom Ed Edd n Eddy 'facts book' meme.
        /// </summary>      
        public async Task<MemoryStream> Facts(string text)
            => await RequestFunctions.ImageRequest($"facts?text={text}", Token);

        /// <summary>
        /// Contains all filters.
        /// </summary>      
        public async Task<MemoryStream> Filter(string imageUrl, FilterType filter)
        {
            string filterName;
            if (filter == FilterType.Random)
            {
                Array values = Enum.GetValues(typeof(FilterType));
                filterName = values.GetValue(new Random().Next(values.Length - 1)).ToString().ToLower();
            }
            else
                filterName = filter.ToString().ToLower();

            filterName = filterName.Replace("blackandwhite", "b&w");

            return await RequestFunctions.ImageRequest($"filter/{filterName}?image={imageUrl}", Token);
        }    

        /// <summary>
        /// Returns a MemoryStream for your own 'the floor is ...' meme.
        /// </summary>        
        public async Task<MemoryStream> TheFloorIs(string text, string imageUrl)
            => await RequestFunctions.ImageRequest($"floor?image={imageUrl}&text={text}", Token);

        /// <summary>
        /// Returns a random fuck my life quote.
        /// </summary>       
        public async Task<string> Fml()
            => await RequestFunctions.JsonRequest("fml", "text", Token);

        /// <summary>
        /// Returns a MemoryStream for an image when a joke flies over someone's head.
        /// </summary>      
        public async Task<MemoryStream> JokeOverHead(string imageUrl)
            => await RequestFunctions.ImageRequest($"jokeoverhead?image={imageUrl}", Token);

        /// <summary>
        /// Returns a MemoryStream for your custom PornHub logo.
        /// </summary>       
        public async Task<MemoryStream> PornHub(string text, string text2)
            => await RequestFunctions.ImageRequest($"pornhub?text={text}&text2={text2}", Token);

        /// <summary>
        /// Returns a url to a random sadcat image.
        /// </summary>       
        public async Task<string> Sadcat()
            => await RequestFunctions.JsonRequest("sadcat", "file", Token);

        /// <summary>
        /// Returns a MemoryStream to indicate that someone is salty.
        /// </summary>       
        public async Task<MemoryStream> Salty(string imageUrl)
            => await RequestFunctions.ImageRequest($"salty?image={imageUrl}", Token);

        /// <summary>
        /// Returns a MemoryStream for your own 'scroll of truth' meme.
        /// </summary>       
        public async Task<MemoryStream> Scroll(string text)
            => await RequestFunctions.ImageRequest($"scroll?text={text}", Token);

        /// <summary>
        /// Returns a MemoryStream for your own Total Drama Island's 'Dock of Shame' meme.
        /// </summary>       
        public async Task<MemoryStream> Shame(string imageUrl)
        {
            return await RequestFunctions.ImageRequest($"shame?image={imageUrl}", Token);
        }

        /// <summary>
        /// Returns a MemoryStream for your custom PornHub logo.
        /// </summary>       
        public async Task<MemoryStream> Ship(string user1Avatar, string user2Avatar)
            => await RequestFunctions.ImageRequest($"ship?user={user1Avatar}&user2={user2Avatar}", Token);

        /// <summary>
        /// Returns a MemoryStream for your custom Supreme logo.
        /// </summary>        
        public async Task<MemoryStream> Supreme(string text, LogoType logoType = LogoType.Normal)
        {
            string mode = logoType switch
            {
                LogoType.Dark => "&dark=true",
                LogoType.Light => "&light=true",
                _ => ""
            };
            return await RequestFunctions.ImageRequest($"supreme?text={text}{mode}", Token);
        }

        /// <summary>
        /// Returns a MemoryStream to show that someone belongs in the trash.
        /// </summary>        
        public async Task<MemoryStream> Trash(string faceAvatarUrl, string trashAvatarUrl)
            => await RequestFunctions.ImageRequest($"trash?face={faceAvatarUrl}&trash={trashAvatarUrl}", Token);

        /// <summary>
        /// Returns a MemoryStream for an 'Earthbound what' meme.
        /// </summary>       
        public async Task<MemoryStream> What(string imageUrl)
            => await RequestFunctions.ImageRequest($"what?image={imageUrl}", Token);
    }    
}
