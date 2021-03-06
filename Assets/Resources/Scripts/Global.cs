﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Global : MonoBehaviour {

    private int mLives=5;
    public Text mLivesText;

    private int mScore;
    public Text mScoreText;

    private float initPower = 200;
    private float mCurrentPower;

    private float mVillagerCount;
    private float mKillCount;

    private ObjectiveManager.Objectives mCurrentObjective = ObjectiveManager.Objectives.Save20;

    public Image GameoverImage;
    public Text GameOverText;

    public static bool killMessage = false;

    public AudioClip LooseAudio;

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
            //Time.timeScale = 0;
            GameoverImage.enabled = true;
            GameOverText.enabled = true;
            GameoverImage.gameObject.SetActive(true);
            GameObject.Find("Audio").GetComponent<AudioSource>().PlayOneShot(LooseAudio);
        }
        else
        {

        }
    }

    public void KilledVillager()
    {
        var gos = GameObject.FindGameObjectsWithTag("Villager");
        for (int i = 0; i < gos.Length; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                gos[i].SendMessage("ShowKillMessage");
            }
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
        deltaPower(5);
    }

    public void SetObjectiveToKill()
    {
        mKillCount = 0;
        mCurrentObjective = ObjectiveManager.Objectives.Kill30;
        mCurrentPower = initPower;
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
        mCurrentPower = Mathf.Clamp(mCurrentPower, -5, initPower);
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

    public void LoadMenu()
    {
        Time.timeScale = 1;
        Destroy(GameObject.Find("Audio"));
        Application.LoadLevel("Menu");
    }
}
