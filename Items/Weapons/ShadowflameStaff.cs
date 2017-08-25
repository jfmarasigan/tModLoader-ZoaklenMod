using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Weapons
{
	//imported from my tAPI mod because I'm lazy
	public class ShadowflameStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shadowflame Staff";
			item.damage = 50;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.toolTip = "Summons a shadowflame apparition to fight for you.";
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = 9;
			item.useSound = 44;
			item.shoot = mod.ProjectileType("ShadowflameApparition");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("ShadowflameApparition");
			item.buffTime = 3600;
		}
	}
}