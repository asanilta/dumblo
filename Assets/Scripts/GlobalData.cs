using UnityEngine;
using System.Collections;

public static class GlobalData {
	public static string player_name = PlayerPrefs.GetString ("player_name", "Player");

	public static uint player_gender = (uint) (int) PlayerPrefs.GetInt ("player_gender", 0);
	public static uint player_level = (uint) (int) PlayerPrefs.GetInt ("player_level", 1);
	public static uint player_exp = (uint) (int) PlayerPrefs.GetInt ("player_exp", 0);
	public static uint next_exp;
	public static uint last_exp = 0;

	public static uint avatar_hair = (uint) (int) PlayerPrefs.GetInt ("avatar_hair", 0);
	public static uint avatar_top = (uint) (int) PlayerPrefs.GetInt ("avatar_top", 0);
	public static uint avatar_bottom = (uint) (int) PlayerPrefs.GetInt ("avatar_bottom", 0);
	public static uint frame = (uint) (int) PlayerPrefs.GetInt ("frame", 0);

	public static string unlocked_hair = PlayerPrefs.GetString ("unlocked_hair", "Player");
	public static string unlocked_top = PlayerPrefs.GetString ("unlocked_top", "Player");
	public static string unlocked_bottom = PlayerPrefs.GetString ("unlocked_bottom", "Player");
	public static string unlocked_frame = PlayerPrefs.GetString ("unlocked_frame", "Player");

	public static uint money = (uint) (int) PlayerPrefs.GetInt ("money", 0);
	public static uint gems = (uint) (int) PlayerPrefs.GetInt ("gems", 0);

	public static uint item_moneybooster = (uint) (int) PlayerPrefs.GetInt ("item_moneybooster", 0);
	public static uint item_removepair = (uint) (int) PlayerPrefs.GetInt ("item_removepair", 0);
	public static uint item_timebooster = (uint) (int) PlayerPrefs.GetInt ("item_timebooster", 0);

	public static byte volume_music;
	public static byte volume_sfx;
	public static bool sound_on = PlayerPrefs.GetInt("sound_on", 1) == 1? true : false;

	public static bool notification_on = PlayerPrefs.GetInt("notification_on", 1) == 1? true : false;

	public static bool new_player = PlayerPrefs.GetInt("new_player", 1) == 1? true : false;

	public static bool ability_updated = false;
	public static bool currency_updated = false;
	public static bool level_updated = false;

}
