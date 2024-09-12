using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace Twosmallballs;

public class ModEntry : Mod
{
    public override void Entry(IModHelper helper)
    {
        helper.Events.Content.AssetRequested += OnAssetRequested;
    }
    private void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
    {
        if (e.Name.IsEquivalentTo("Data/Objects"))
        {
            e.Edit(asset =>
            {
                var dict = asset.AsDictionary<string, ObjectData>();

                var Bomm = new ObjectData
                {
                    Name = "Twosmallballs.Bomm",
                    DisplayName = "酒心炸弹",
                    DescriptionAttribute = "威力很大的炸弹，爆炸后会散发酒香",
                    Type = "Crafting",
                    Category = StardewValley.Object.FruitsCategory,
                    Price = 500,
                    Textrue = "Twosmallballs.Bomm"
                };

                dict.Data["Twosmallballs.Bomm"] = Bomm;

            });
        }
        if (e.Name.IsEquivalentTo("Twosmallballs.Bomm"))
        {
            e.LoadFromModFile<Textrue2D>("assets/Bomm.png", AssetLoadPriority.Medium);
        }

    }

}
