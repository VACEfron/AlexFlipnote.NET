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
