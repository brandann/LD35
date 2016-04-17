using UnityEngine;
using System.Collections;

public class ResetTimer : MonoBehaviour {

    private float starttime;
    private float dur;
    private bool started;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(started)
        {
            if((Time.timeSinceLevelLoad - starttime) > dur)
            {
                Application.LoadLevel("Menu");
            }
        }
	}

    public void StartTimer(float d)
    {
        started = true;
        dur = d;
        starttime = Time.timeSinceLevelLoad;
    }
}
