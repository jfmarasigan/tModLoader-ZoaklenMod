using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ChameleonWarriorBreastplate : ModItem
	{
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			if(Main.gameMenu || !((PlayerChanges)drawPlayer.GetModPlayer(mod, "PlayerChanges")).chameleonMode)
			{
				color = new Color(43, 163, 80);
			}
			else
			{
				BiomeInformations biome = new BiomeInformations();
				biome.player = drawPlayer;
				biome.UpdateInfos();
				color = biome.color;
			}
		}

		public override void ArmorArmGlowMask(Player drawPlayer, float shadow, ref int glowMask, ref Color color)
		{
			if(Main.gameMenu)
			{
				color = new Color(43, 163, 80);
			}
			else
			{
				BiomeInformations biome = new BiomeInformations();
				biome.player = drawPlayer;
				biome.UpdateInfos();
				color = biome.color;
			}
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chameleon Warrior Breastplate");
			Tooltip.SetDefault("6% increased throwing damage\n" +
				"8% increased throwing critical strike chance");
		}

		public override void SetDefaults()
		{
			item.value = 240000;
			item.rare = 7;
			item.defense = 17;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.06f;
			player.thrownCrit += 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PaladinBar"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}