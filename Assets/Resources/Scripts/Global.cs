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
    private float mKillCount;

    private ObjectiveManager.Objectives mCurrentObjective = ObjectiveManager.Objectives.Save20;

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
        if(mCurrentObjective == ObjectiveManager.Objectives.Save20)
        {
            if(mVillagerCount == 20)
            {
                GameObject.Find("Main Camera").SendMessage("SaveObjectiveAcheived");
            }
        }        
    }

    public void GainScore()
    {
        mScore++;
        deltaPower(1);
    }

    public void SetObjectiveToKill()
    {
        mKillCount = 0;
        mCurrentObjective = ObjectiveManager.Objectives.Kill30;
    }

    public void MakeKill()
    {
        mKillCount++;
        if (mCurrentObjective == ObjectiveManager.Objectives.Kill30)
        {
            if (mKillCount == 30)
            {
                GameObject.Find("Main Camera").SendMessage("KillObjectiveAcheived");
            }
        } 
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
