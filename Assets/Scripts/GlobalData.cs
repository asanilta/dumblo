using UnityEngine;
using System.Collections;

public static class GlobalData {
	public static string player_name;

	public static uint player_level;
	public static uint player_exp;
	public static uint next_exp;
	public static uint last_exp;

	public static uint avatar_hair;
	public static uint avatar_top;
	public static uint avatar_bottom;
	public static uint avatar_accessories;
	public static uint frame;

	public static ArrayList unlocked_hair;
	public static ArrayList unlocked_top;
	public static ArrayList unlocked_bottom;
	public static ArrayList unlocked_accessories;
	public static ArrayList unlocked_frame;

	public static uint money;
	public static uint gems;

	public static uint item_moneybooster;
	public static uint item_removepair;
	public static uint item_timebooster;

	public static byte volume_music;
	public static byte volume_sfx;

	public static bool notification_on;

	public static bool ability_updated = false;
	public static bool currency_updated = false;
	public static bool level_updated = false;
}
