using UnityEngine;
using System.Collections;

public class DontKillUs : MonoBehaviour {


    private float mStartTime;
    private float mDuration = 2;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if((Time.timeSinceLevelLoad - mStartTime) > mDuration)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
	}

    public void ShowDontKillUs()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        mStartTime = Time.timeSinceLevelLoad;
    }
}
