using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Items.Marks
{
	public abstract class MarkBase : ModItem
	{
		public int markId;
		public bool activated;
		public int itemDuration = 300;

		public override void SetStaticDefaults()
		{
			MarkStaticDefaults();
			Tooltip.SetDefault(Tooltip.GetDefault() + "\n" +
				"Right-click to activate\n" +
				"'Worths like a trove'");
		}

		public override void SetDefaults()
		{
			MarkDefaults();
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override bool ConsumeItem(Player player)
		{
			return false;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(item.type);
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(modPlayer.activeMark != markId)
			{
				modPlayer.activeMark = markId;
				modPlayer.markDuration = itemDuration;
				Main.NewText("<" + player.name + "> just set it mark to " + DisplayName.GetDefault() + ".", 255, 0, 255);
			}
		}

		public override void UpdateInventory(Player player)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(modPlayer.markActivated && modPlayer.activeMark == markId)
			{
				activated = true;
				modPlayer.markFrames++;
				if(modPlayer.markFrames <= modPlayer.markDuration)
				{
					MarkEffect(player);
				}
				else
				{
					modPlayer.markActivated = false;
					modPlayer.markFrames = 0;
				}
			}
			else
			{
				activated = false;
			}
		}

		public abstract void MarkEffect(Player player);

		public abstract void MarkStaticDefaults();

		public abstract void MarkDefaults();
	}
}