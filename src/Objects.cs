namespace AlexFlipnote.NET
{
    public class Color
    {
        public string BlackOrWhiteText { get; set; }
        public int Brightness { get; set; }
        public string Hex { get; set; }
        public string ImageUrl { get; set; }
        public string GradientImageUrl { get; set; }
        public int Int { get; set; }
        public string Name { get; set; }
        public string RGB { get; set; }
        public RgbValue RGBValue { get; set; }
        public string[] Shades { get; set; }
        public string[] Tints { get; set; }

        public class RgbValue
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }
        }
    }

    public class Steam
    {
        public SteamID SteamId { get; set; }
        public SteamAvatar Avatar { get; set; }
        public SteamProfile Profile { get; set; }

        public class SteamID
        {
            public string SteamId3 { get; set; }
            public string SteamId32 { get; set; }
            public string SteamId64 { get; set; }
            public string CustomUrl { get; set; }
        }
        public class SteamAvatar
        {
            public string AvatarSmall { get; set; }
            public string AvatarMedium { get; set; }
            public string AvatarFull { get; set; }
        }
        public class SteamProfile
        {
            public string Username { get; set; }
#nullable enable
            public string? Realname { get; set; }
#nullable disable
            public string Url { get; set; }
            public string Summary { get; set; }
            public string Background { get; set; }
            public string Location { get; set; }
            public string Status { get; set; }
            public string Privacy { get; set; }
            public string TimeCreated { get; set; }
            public bool VACBanned { get; set; }
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
        Wide,
        Snow,
        Gay,
        Pixelate,
        Jpegify,
        Magik,
        Communist,
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
