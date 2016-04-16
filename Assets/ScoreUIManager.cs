using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUIManager : MonoBehaviour {

    private Text mScoreText;
    private Global mGlobal;
    private string Label;

	// Use this for initialization
	void Start () {
        mScoreText = this.GetComponent<Text>();
        mGlobal = GameObject.Find("Global").GetComponent<Global>();
        Label = mScoreText.text;
	}
	
	// Update is called once per frame
	void Update () {
        if(Label == "Lives")
        {
            mScoreText.text = Label + ": " + mGlobal.GetLives();
        }
        else if(Label == "Score")
        {
            mScoreText.text = Label + ": " + mGlobal.GetScore();
        }
        else if(Label == "Power")
        {
            mScoreText.text = Label + ": " + mGlobal.GetPowerDisplay();
        }
        else
        {
            mScoreText.text = "--";
        }
        
	}
}
