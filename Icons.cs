using System.Collections.Generic;
using System.Linq;
using ExileCore2.Shared.Enums;
using ExpeditionIcons.PathPlannerData;

namespace ExpeditionIcons;

public static class Icons
{
    public static IExpeditionRelic GetRelicType(string relicMod, PlannerSettings plannerSettings)
    {
        var relicDescription = ExpeditionRelicIcons.FirstOrDefault(x => x.BaseEntityMetadataSubstrings.Contains(relicMod));
        return (relicMod, relicDescription) switch
        {
            ("ExpeditionRelicUpsideElitesDuplicated", _) => new DoubledMonstersRelic(),
            (_, { IsWeightCustomizable: true, IconPickerIndex: var index }) when
                (plannerSettings.RelicSettingsMap.GetValueOrDefault(index) ?? RelicSettings.Default) is var setting =>
                new ConfigurableRelic(setting.Multiplier, setting.Increase,
                    relicMod.Contains("Monster") || relicMod.Contains("Elite") || relicMod.Contains("PackSize")),
            _ when relicMod.Contains("Monster") => new ConfigurableRelic(plannerSettings.DefaultRelicSettings.Multiplier, plannerSettings.DefaultRelicSettings.Increase, true),
            _ when relicMod.Contains("Chest") => new ConfigurableRelic(plannerSettings.DefaultRelicSettings.Multiplier, plannerSettings.DefaultRelicSettings.Increase, false),
            _ => null,
        };
    }

    public static readonly List<ExpeditionMarkerIconDescription> ExpeditionRelicIcons = new()
    {
        new()
        {
            IconPickerIndex = IconPickerIndex.CorruptedItems,
            DefaultIcon = MapIconsIndex.QuestObject,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideCorruptedDropChanceVaal",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Experience,
            DefaultIcon = MapIconsIndex.QuestObject,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideExperience",
                "ExpeditionRelicUpsideExperienceKarui"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Rarity,
            DefaultIcon = MapIconsIndex.RewardUniques,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideItemRarityMonster",
                "ExpeditionRelicUpsideItemRarityMonsterEzomyte"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Logbooks,
            DefaultIcon = MapIconsIndex.QuestItem,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideExpeditionLogbookQuantityMonster",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.PackSize,
            DefaultIcon = MapIconsIndex.LootFilterLargeGreenTriangle,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsidePackSize",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.MonsterMods,
            DefaultIcon = MapIconsIndex.LootFilterLargeGreenTriangle,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideRareMonsterChance",
                "ExpeditionRelicUpsideMagicMonsterChance",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Goblin,
            DefaultIcon = MapIconsIndex.LootFilterLargeGreenTriangle,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideMagicRareMonsterChanceGoblin",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.RunicMonsterDuplication,
            DefaultIcon = MapIconsIndex.IncursionArchitectReplace,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideElitesDuplicated",
            },
            IsWeightCustomizable = false,
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Quantity,
            DefaultIcon = MapIconsIndex.RewardGenericItems,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideItemQuantityMonster",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.RarityExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardUniques,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideItemRarityChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.QuantityExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardGenericItems,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideItemQuantityChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.ArtifactsExcavatedChest,
            DefaultIcon = MapIconsIndex.LootFilterLargePurpleSquare,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideItemQuantityChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Artifacts,
            DefaultIcon = MapIconsIndex.LootFilterLargePurpleSquare,
            BaseEntityMetadataSubstrings =
            {

                "ExpeditionRelicUpsideIncreasedArtifactsMonster",
            },
        },
    };

    public static readonly List<ExpeditionMarkerIconDescription> LogbookChestIcons = new()
    {
        new()
        {
            IconPickerIndex = IconPickerIndex.BlightChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestBlight.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.FragmentChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestFragments.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.LeagueChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestLeague.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.JewelleryChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestTrinkets.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.WeaponChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestWeapon.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.CurrencyChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestCurrency.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.HeistChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestHeist.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.BreachChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestBreach.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.RitualChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestRitual.ao"
            },
        },
        /*
        new()
        {
            IconPickerIndex = IconPickerIndex.MetamorphChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestMetamorph.ao"
            },
        },
        */
        new()
        {
            IconPickerIndex = IconPickerIndex.MapsChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestMaps.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.GemsChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestGems.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.FossilsChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestFossils.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.DivinationCardsChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestDivinationCards.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.EssenceChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestEssence.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.ArmourChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestArmour.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.LegionChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestLegion.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.DeliriumChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestDelirium.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.UniquesChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestUniques.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.OtherChests,
            DefaultIcon = MapIconsIndex.MissionAlly,
            BaseEntityMetadataSubstrings =
            {
                "chestmarker1",
                "chestmarker2",
                "chestmarker3",
                "chestmarker_signpost",
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers"
            },
        },
    };
}