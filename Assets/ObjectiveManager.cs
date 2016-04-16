using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveManager : MonoBehaviour {

    public List<string> mObjectiveList;
    public Text ObjectiveText;
    public Image ObjectiveTextBox;

    private float mStartTime;
    private float mDuration = 2;

	// Use this for initialization
	void Start () {
        mStartTime = Time.timeSinceLevelLoad;
        ObjectiveText.text = mObjectiveList[0];
	}
	
	// Update is called once per frame
	void Update () {
	    if((Time.timeSinceLevelLoad - mStartTime) > mDuration)
        {
            ObjectiveTextBox.enabled = false;
            ObjectiveText.enabled = false;
        }
	}

    public void ObjectiveAcheived()
    {
        //Time.timeScale = 0;
        //KillAllVillagers();
        GameObject.Find("Spawner").SetActive(false);
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
