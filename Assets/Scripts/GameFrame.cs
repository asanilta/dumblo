using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameFrame : MonoBehaviour {

	public Texture frame;

		void OnGUI(){ GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), frame); }
}
