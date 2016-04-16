using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Global : MonoBehaviour {

    private int mLives;
    public int StartLives;
    public Text mLivesText;

    private int mScore;
    public Text mScoreText;

    public float initPower;
    private float mCurrentPower;

	// Use this for initialization
	void Start () {
        mLives = StartLives;
        mScore = 0;
        mCurrentPower = initPower;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LooseLife()
    {
        mLives--;
        if(mLives == 0)
        {
            //print("Game Over!!");
        }
        else
        {

        }
    }

    public void GainScore()
    {
        mScore++;
    }

    public int GetScore()
    {
        return mScore;
    }

    public int GetLives()
    {
        return mLives;
    }

    public void deltaPower(float d)
    {
        mCurrentPower += d;
    }

    public float GetPower()
    {
        return mCurrentPower;
    }

    public string GetPowerDisplay()
    {
        float p = 100 * (mCurrentPower / initPower);
        return "" + p + "%";
    }

    public bool HasPower()
    {
        return mCurrentPower > 0;
    }
}
