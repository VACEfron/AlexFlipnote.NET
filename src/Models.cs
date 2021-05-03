using Newtonsoft.Json;

namespace AlexFlipnote.NET
{
    public class Color
    {
        [JsonProperty("blackorwhite_text")]
        public string BlackOrWhiteText { get; set; }
        public int Brightness { get; set; }
        public string Hex { get; set; }
        [JsonProperty("image")]
        public string ImageUrl { get; set; }
        [JsonProperty("image_gradient")]
        public string GradientImageUrl { get; set; }
        public int Int { get; set; }
        public string Name { get; set; }
        public string Rgb { get; set; }
        [JsonProperty("rgb_values")]
        public RGBValue RgbValue { get; set; }
        [JsonProperty("shade")]
        public string[] Shades { get; set; }
        [JsonProperty("tint")]
        public string[] Tints { get; set; }

        public struct RGBValue
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }
        }
    }

    /// <summary>
    /// Logo types for the Supreme endpoint.
    /// </summary>
    public enum LogoType
    {
        Normal,
        Dark,
        Light
    }

    /// <summary>
    /// Filters options for the filter endpoints.
    /// </summary>
    public enum FilterType
    {
        Blur,
        Invert,
        BlackAndWhite,
        DeepFry,
        Sepia,
        Wide,
        Snow,
        Gay,
        Pixelate,
        Jpegify,
        Magik,
        Communist,
        Flip,
        Mirror,
        Random
    }

    /// <summary>
    /// Minecraft icons for the achievement and challenge endpoints.
    /// </summary>
    public enum Icon
    {
        GrassBlock = 1,
        Diamond,
        DiamondSword,
        Creeper,
        Pig,
        TNT,
        Cookie,
        Heart,
        Bed,
        Cake,
        Sign,
        Rail,
        CraftingTable,
        Redstone,
        Fire,
        Cobweb,
        Chest,
        Furnace,
        Book,
        StoneBlock,
        WoodenPlank,
        IronIngot,
        GoldIngot,
        WoodenDoor,
        IronDoor,
        DiamondChestplate,
        FlintAndSteel,
        GlassBottle,
        SplashPotion,
        CreeperSpawnEgg,
        Coal,
        IronSword,
        Bow,
        Arrow,
        IronChestplate,
        Bucket,
        WaterBucket,
        LavaBucket,
        MilkBucket,
        DiamondBoots,
        WoodenHoe,
        Bread,
        WoodenSword,
        Bone,
        OakLog,
        Random
    }
}
