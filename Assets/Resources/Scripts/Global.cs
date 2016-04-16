using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Global : MonoBehaviour {

    private int mLives=5;
    public Text mLivesText;

    private int mScore;
    public Text mScoreText;

    private float initPower = 100;
    private float mCurrentPower;

    private float mVillagerCount;

	// Use this for initialization
	void Start () {
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

    public void SaveVillager()
    {
        mVillagerCount++;
        if(mVillagerCount > 20)
        {
            GameObject.Find("Main Camera").SendMessage("ObjectiveAcheived");
        }
    }

    public void GainScore()
    {
        mScore++;
        print("" + (5 * Time.deltaTime));
        deltaPower(1);
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
        mCurrentPower = Mathf.Clamp(mCurrentPower, 0, initPower);
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
