using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace AlexFlipnote.NET
{
    public static class AlexEndpoints
    {
        /// <summary>
        /// Returns a MemoryStream for your custom Minecraft-style 'achievement unlocked' popup.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Achievement(string Text, int? Icon = null)
        {
            string iconString = "";
            if (Icon != null) iconString = "&" + Icon.ToString();

            return RequestFunctions.ImageRequest($"achievement?text={Text}{iconString}");
        }

        /// <summary>
        /// Returns a MemoryStream for your own image over the 'Am I a joke to you?' meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream AmIAJoke(string ImageUrl)
        {
            return RequestFunctions.ImageRequest($"amiajoke?image={ImageUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for showing how bad someone is.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Bad(string ImageUrl)
        {
            return RequestFunctions.ImageRequest($"bad?image={ImageUrl}");
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
        public static MemoryStream Calling(string Text)
        {
            return RequestFunctions.ImageRequest($"calling?text={Text}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom captcha image.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Captcha(string Text)
        {
            return RequestFunctions.ImageRequest($"captcha?text={Text}");
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
        public static MemoryStream Challenge(string Text, int? Icon = null)
        {
            string iconString = "";
            if (Icon != null) iconString = "&" + Icon.ToString();

            return RequestFunctions.ImageRequest($"challenge?text={Text}{iconString}");
        }

        /// <summary>
        /// Returns a MemoryStream for a fake Google 'did you mean' image.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream DidYouMean(string TopText, string BottomText)
        {
            return RequestFunctions.ImageRequest($"didyoumean?top={TopText}&bottom={BottomText}");
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
        public static MemoryStream Drake(string TopText, string BottomText)
        {
            return RequestFunctions.ImageRequest($"drake?top={TopText}&bottom={BottomText}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom Ed Edd n Eddy 'facts book' meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Facts(string Text)
        {
            return RequestFunctions.ImageRequest($"facts?text={Text}");
        }

        /// <summary>
        /// Returns a MemoryStream for your own 'the floor is ...' meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream TheFloorIs(string Text, string ImageUrl)
        {
            return RequestFunctions.ImageRequest($"floor?image={ImageUrl}&text={Text}");
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
        public static MemoryStream JokeOverHead(string ImageUrl)
        {
            return RequestFunctions.ImageRequest($"jokeoverhead?image={ImageUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom PornHub logo.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream PornHub(string Text, string Text2)
        {
            return RequestFunctions.ImageRequest($"pornhub?text={Text}&text2={Text2}");
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
        public static MemoryStream Salty(string ImageUrl)
        {
            return RequestFunctions.ImageRequest($"salty?image={ImageUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for your own 'scroll of truth' meme.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Scroll(string Text)
        {
            return RequestFunctions.ImageRequest($"scroll?text={Text}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom PornHub logo.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Ship(string User1Avatar, string User2Avatar)
        {
            return RequestFunctions.ImageRequest($"ship?user={User1Avatar}&user2={User2Avatar}");
        }

        /// <summary>
        /// Returns a MemoryStream for your custom Supreme logo.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Supreme(string Text, LogoType LogoType = LogoType.Normal)
        {
            string Mode = "";
            switch (LogoType)
            {
                case LogoType.Dark:
                    Mode = "&dark=true";
                    break;
                case LogoType.Light:
                    Mode = "&light=true";
                    break;
            }
            return RequestFunctions.ImageRequest($"supreme?text={Text}{Mode}");
        }

        /// <summary>
        /// Returns a MemoryStream to show that someone belongs in the trash.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream Trash(string FaceAvatarUrl, string TrashAvatarUrl)
        {
            return RequestFunctions.ImageRequest($"trash?face={FaceAvatarUrl}&trash={TrashAvatarUrl}");
        }

        /// <summary>
        /// Returns an object with all provided color info.
        /// </summary>
        /// <returns></returns>
        public static Color Color(string Hex = "random")
        {
            if (Hex == "random")
                Hex = string.Format("{0:X6}", new Random().Next(0x1000000));

            var data = RequestFunctions.JObjectRequest($"color/{Hex}");
            return GetColor(data);
        }

        private static Color GetColor(JObject data)
        {
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
        /// Returns an object with all provided Steam profile info.
        /// </summary>
        /// <returns></returns>
        public static Steam Steam(string SteamId)
        {
            var data = RequestFunctions.JObjectRequest($"steam/user/{SteamId}");

            var Steam = new Steam
            {
                SteamId = new Steam.IDs
                {
                    SteamId3 = data["id"]["steamid3"].Value<string>(),
                    SteamId32 = data["id"]["steamid32"].Value<string>(),
                    SteamId64 = data["id"]["steamid64"].Value<string>(),
                    CustomUrl = data["id"]["customurl"].Value<string>()
                },
                Avatar = new Steam.SteamAvatar
                {
                    AvatarSmall = data["avatars"]["avatar"].Value<string>(),
                    AvatarMedium = data["avatars"]["avatarmedium"].Value<string>(),
                    AvatarFull = data["avatars"]["avatarfull"].Value<string>(),
                },
                Profile = new Steam.SteamProfile
                {
                    Username = data["profile"]["username"].Value<string>(),
                    Realname = data["profile"]["realname"].Value<string>() ?? null,
                    Url = data["profile"]["url"].Value<string>(),
                    Summary = data["profile"]["summary"].Value<string>(),
                    Background = data["profile"]["background"].Value<string>(),
                    Location = data["profile"]["location"].Value<string>(),
                    Status = data["profile"]["state"].Value<string>(),
                    Privacy = data["profile"]["privacy"].Value<string>(),
                    TimeCreated = data["profile"]["timecreated"].Value<string>(),
                    VACBanned = data["profile"]["vacbanned"].Value<bool>()
                }
            };

            return Steam;
        }
    }    
}
