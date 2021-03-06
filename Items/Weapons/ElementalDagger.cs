using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	public class ElementalDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Dagger");
			Tooltip.SetDefault("'Its temperature changes everytime'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 9));
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MagicDagger);
			item.magic = false;
			item.thrown = true;
			item.width = 14;
			item.height = 28;
			item.rare = 6;
			item.mana = 0;
			item.shootSpeed *= 1.1f;
			item.damage = 40;
			item.autoReuse = true;
			item.useTime = 12;
			item.shoot = mod.ProjectileType("ElementalDagger");
			item.crit = 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MagicDagger"));
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(mod.ItemType("FireEssence"), 5);
			recipe.AddIngredient(mod.ItemType("ShadowEssence"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MagicDagger);
			recipe.AddIngredient(mod.ItemType("IceEssence"), 5);
			recipe.AddIngredient(mod.ItemType("FireEssence"), 5);
			recipe.AddIngredient(mod.ItemType("ShadowEssence"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}