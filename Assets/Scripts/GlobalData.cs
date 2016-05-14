using UnityEngine;
using System.Collections;

public static class GlobalData {
	public static string player_name = PlayerPrefs.GetString ("player_name", "Player");

	public static uint player_level = (uint) (int) PlayerPrefs.GetInt ("player_level", 1);
	public static uint player_exp = (uint) (int) PlayerPrefs.GetInt ("player_exp", 0);
	public static uint next_exp;
	public static uint last_exp = 0;

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

	public static uint money = (uint) (int) PlayerPrefs.GetInt ("money", 0);
	public static uint gems = (uint) (int) PlayerPrefs.GetInt ("gems", 0);

	public static uint item_moneybooster = (uint) (int) PlayerPrefs.GetInt ("item_moneybooster", 0);
	public static uint item_removepair = (uint) (int) PlayerPrefs.GetInt ("item_removepair", 0);
	public static uint item_timebooster = (uint) (int) PlayerPrefs.GetInt ("item_timebooster", 0);

	public static byte volume_music;
	public static byte volume_sfx;

	public static bool notification_on;

	public static bool ability_updated = false;
	public static bool currency_updated = false;
	public static bool level_updated = false;
}
