using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace AlexFlipnote.NET
{
    /// <summary>
    /// Class which contains all methods for the endpoints.
    /// </summary>
    public static class AlexEndpoint
    {
        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'achievement unlocked' popup.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Achievement(string text, Icon icon)
        {
            int iconInt;

            if (icon == Icon.Random)
                iconInt = new Random().Next(1, 45);
            else
                iconInt = (int)icon;
            
            return RequestFunctions.ImageRequest($"achievement?text={text}&icon={iconInt}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'achievement unlocked' popup.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Achievement(string text, int? icon = null)
        {
            if (icon is null)
                icon = new Random().Next(1, 45);
            
            return RequestFunctions.ImageRequest($"achievement?text={text}&icon={icon}");
        }        

        /// <summary>
        /// Returns a MemoryStream for your own image over the 'Am I a joke to you?' meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream AmIAJoke(string imageUrl)
        {
            return RequestFunctions.ImageRequest($"amiajoke?image={imageUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for showing how bad someone is.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Bad(string imageUrl)
        {
            return RequestFunctions.ImageRequest($"bad?image={imageUrl}");
        }

        /// <summary>
        /// Returns a url to a random birb image.
        /// </summary>
        /// <returns></returns>
        public static string Birb()
        {
            return RequestFunctions.JsonRequest("birb", "file");
        }

        /// <summary>
        /// Returns a MemoryStream for your own 'Tom calling' reaction meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Calling(string text)
        {
            return RequestFunctions.ImageRequest($"calling?text={text}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom captcha image.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Captcha(string text)
        {
            return RequestFunctions.ImageRequest($"captcha?text={text}");
        }

        /// <summary>
        /// Returns a url to a random cat image.
        /// </summary>
        /// <returns></returns>
        public static string Cats()
        {
            return RequestFunctions.JsonRequest("cats", "file");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'challenge completed' popup.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Challenge(string text, Icon icon)
        {
            int iconInt;

            if (icon == Icon.Random)
                iconInt = new Random().Next(1, 44);
            else
                iconInt = (int)icon;

            return RequestFunctions.ImageRequest($"challenge?text={text}&icon={iconInt}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'challenge completed' popup.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Challenge(string text, int? icon = null)
        {
            if (icon is null)
                icon = new Random().Next(1, 44);

            return RequestFunctions.ImageRequest($"challenge?text={text}&icon={icon}");
        }

        /// <summary>
        /// Returns an object with all provided color info.
        /// </summary>
        /// <returns></returns>
        public static Color Color(string hex = "random")
        {
            if (hex == "random")
                hex = string.Format("{0:X6}", new Random().Next(0x1000000));

            JObject data = RequestFunctions.JObjectRequest($"color/{hex}");

            var Color = new Color
            {
                BlackOrWhiteText = data["blackorwhite_text"].Value<string>(),
                Brightness = data["brightness"].Value<int>(),
                Hex = data["hex"].Value<string>(),
                ImageUrl = data["image"].Value<string>(),
                GradientImageUrl = data["image_gradient"].Value<string>(),
                Int = data["int"].Value<int>(),
                Name = data["name"].Value<string>(),
                RGB = data["rgb"].Value<string>(),
                RGBValue = new Color.RgbValue
                {
                    R = data["rgb_values"]["r"].Value<int>(),
                    G = data["rgb_values"]["g"].Value<int>(),
                    B = data["rgb_values"]["b"].Value<int>()
                },
                Shades = JsonConvert.DeserializeObject<string[]>(data["shade"].ToString()),
                Tints = JsonConvert.DeserializeObject<string[]>(data["tint"].ToString()),
            };
            return Color;
        }

        /// <summary>
        /// Returns a MemoryStream for an image of a color.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream ColorImage(string hex)
        {
            return RequestFunctions.ImageRequest($"color/image/{hex}");
        }

        /// <summary>
        /// Returns a MemoryStream for a gradient image of a color.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream ColorImageGradient(string hex)
        {
            return RequestFunctions.ImageRequest($"color/image/gradient/{hex}");
        }

        /// <summary>
        /// Returns a MemoryStream for a colourified image.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Colourify(string imageUrl, string colorHex = "", string backgroundHex = "")
        {
            if (colorHex != "")
                colorHex = "&c=" + colorHex;
            if (backgroundHex != "")
                backgroundHex = "&b=" + backgroundHex;

            return RequestFunctions.ImageRequest($"colourify?image={imageUrl}{colorHex}{backgroundHex}");
        }

        /// <summary>
        /// Returns a MemoryStream for a fake Google 'did you mean' image.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream DidYouMean(string topText, string bottomText)
        {
            return RequestFunctions.ImageRequest($"didyoumean?top={topText}&bottom={bottomText}");
        }

        /// <summary>
        /// Returns a url to a random dog image.
        /// </summary>
        /// <returns></returns>
        public static string Dogs()
        {
            return RequestFunctions.JsonRequest("dogs", "file");
        }

        /// <summary>
        /// Returns a MemoryStream for your own drake meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Drake(string topText, string bottomText)
        {
            return RequestFunctions.ImageRequest($"drake?top={topText}&bottom={bottomText}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom Ed Edd n Eddy 'facts book' meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Facts(string text)
        {
            return RequestFunctions.ImageRequest($"facts?text={text}");
        }

        /// <summary>
        /// Contains all filters.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Filter(string imageUrl, FilterType filter)
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

            return RequestFunctions.ImageRequest($"filter/{filterName}?image={imageUrl}");
        }    

        /// <summary>
        /// Returns a MemoryStream for your own 'the floor is ...' meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream TheFloorIs(string text, string imageUrl)
        {
            return RequestFunctions.ImageRequest($"floor?image={imageUrl}&text={text}");
        }

        /// <summary>
        /// Returns a random fuck my life quote.
        /// </summary>
        /// <returns></returns>
        public static string Fml()
        {
            return RequestFunctions.JsonRequest("fml", "text");
        }

        /// <summary>
        /// Returns a MemoryStream for an image when a joke flies over someone's head.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream JokeOverHead(string imageUrl)
        {
            return RequestFunctions.ImageRequest($"jokeoverhead?image={imageUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom PornHub logo.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream PornHub(string text, string text2)
        {
            return RequestFunctions.ImageRequest($"pornhub?text={text}&text2={text2}");
        }

        /// <summary>
        /// Returns a url to a random sadcat image.
        /// </summary>
        /// <returns></returns>
        public static string Sadcat()
        {
            return RequestFunctions.JsonRequest("sadcat", "file");
        }

        /// <summary>
        /// Returns a MemoryStream to indicate that someone is salty.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Salty(string imageUrl)
        {
            return RequestFunctions.ImageRequest($"salty?image={imageUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for your own 'scroll of truth' meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Scroll(string text)
        {
            return RequestFunctions.ImageRequest($"scroll?text={text}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom PornHub logo.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Ship(string user1Avatar, string user2Avatar)
        {
            return RequestFunctions.ImageRequest($"ship?user={user1Avatar}&user2={user2Avatar}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom Supreme logo.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Supreme(string text, LogoType logoType = LogoType.Normal)
        {
            string mode = "";
            switch (logoType)
            {
                case LogoType.Dark:
                    mode = "&dark=true";
                    break;
                case LogoType.Light:
                    mode = "&light=true";
                    break;
            }
            return RequestFunctions.ImageRequest($"supreme?text={text}{mode}");
        }

        /// <summary>
        /// Returns a MemoryStream to show that someone belongs in the trash.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Trash(string faceAvatarUrl, string trashAvatarUrl)
        {
            return RequestFunctions.ImageRequest($"trash?face={faceAvatarUrl}&trash={trashAvatarUrl}");
        }         
    }    
}
