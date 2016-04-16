using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveManager : MonoBehaviour {

    public enum Objectives { Save20, Kill30 };
    public List<string> mObjectiveList;
    public Text ObjectiveText;
    public Image ObjectiveTextBox;

    private float mStartTime;
    private float mDuration = 2;

    private int index = 0;

    public GameObject mSpawner;

	// Use this for initialization
	void Start () {
        mStartTime = Time.timeSinceLevelLoad;
        ObjectiveText.text = mObjectiveList[index];
	}
	
	// Update is called once per frame
	void Update () {
        if(index == 0)
        {
            //SAVE 20 VILLAGERS
            if ((Time.timeSinceLevelLoad - mStartTime) > mDuration)
            {
                ObjectiveTextBox.enabled = false;
                ObjectiveText.enabled = false;
            }
        }
        else if(index == 1)
        {
            //GREAT JOB
            if ((Time.timeSinceLevelLoad - mStartTime) > mDuration)
            {
                ObjectiveTextBox.enabled = false;
                ObjectiveText.enabled = false;
            }

            var gos = GameObject.FindGameObjectsWithTag("Villager");
            if (gos.Length == 0)
            {
                StartKillObjective();
            }
        }
        else if(index == 2)
        {
            //KILL 30 SHAPE SHIFTERS
            if ((Time.timeSinceLevelLoad - mStartTime) > mDuration)
            {
                ObjectiveTextBox.enabled = false;
                ObjectiveText.enabled = false;
            }
        }
        else if(index == 3)
        {
            // YOU ARE KINDA MURDEROUS
            if ((Time.timeSinceLevelLoad - mStartTime) > mDuration)
            {
                ObjectiveTextBox.enabled = false;
                ObjectiveText.enabled = false;
            }
        }



	}

    private void StartKillObjective()
    {
        index++;
        ObjectiveTextBox.enabled = true;
        ObjectiveText.enabled = true;
        ObjectiveText.text = mObjectiveList[index];
        mStartTime = Time.timeSinceLevelLoad;
        mSpawner.SetActive(true);
        GameObject.Find("Global").SendMessage("SetObjectiveToKill");
    }

    public void SaveObjectiveAcheived()
    {
        index++;
        ObjectiveTextBox.enabled = true;
        ObjectiveText.enabled = true;
        ObjectiveText.text = mObjectiveList[index];
        mStartTime = Time.timeSinceLevelLoad;
        mSpawner.SetActive(false);
    }

    public void KillObjectiveAcheived()
    {
        index++;
        ObjectiveTextBox.enabled = true;
        ObjectiveText.enabled = true;
        ObjectiveText.text = mObjectiveList[index];
        mStartTime = Time.timeSinceLevelLoad;
        mSpawner.SetActive(false);
    }

    void KillAllVillagers()
    {
        var gos = GameObject.FindGameObjectsWithTag("Villager");
        for(int i = 0;  i <gos.Length; i++)
        {
            Destroy(gos[i].gameObject);
        }
    }
}
