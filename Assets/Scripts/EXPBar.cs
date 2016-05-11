using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour {
	public RectTransform filler;
	public Text text;

	[Range(1,1000)]
	public int ProgressSpeed;
	// Use this for initialization
	void Start () {
		filler.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, ExpProgress(GlobalData.player_exp));
		text.text = GlobalData.player_exp.ToString() + '/' + GameManager.NextExp (GlobalData.player_level).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalData.last_exp != GlobalData.player_exp)
		{
			GlobalData.last_exp += (uint) (int) Mathf.FloorToInt(ProgressSpeed * Time.deltaTime);
			if (GlobalData.last_exp > GlobalData.player_exp)
				GlobalData.last_exp = GlobalData.player_exp;
			filler.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, ExpProgress(GlobalData.last_exp));
			text.text = GlobalData.player_exp.ToString() + '/' + GameManager.NextExp (GlobalData.player_level).ToString();
		}
	}

	float ExpProgress(uint exp) {
		return exp / GameManager.NextExp(GlobalData.player_level) * filler.rect.width;
	}
}
