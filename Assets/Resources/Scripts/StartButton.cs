using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour {

    public Button mStartButton;
    private float mStart;
    private float mDur = 2.5f;
    private bool start = false;

    public GameObject BM;

    public AudioClip mAudioARG;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if(start)
        {
            if((Time.timeSinceLevelLoad - mStart) > mDur)
            {
                Application.LoadLevel("Tutorial");
            }
        }
	}

    public void OnStartClick()
    {
        mStartButton.gameObject.SetActive(false);
        mStart = Time.timeSinceLevelLoad;
        start = true;
        var go = GameObject.Instantiate(BM);
        go.transform.position = this.transform.position;
        go.GetComponent<BurstManager>().mColor = Color.yellow;
        GameObject.Find("Audio").GetComponent<AudioSource>().PlayOneShot(mAudioARG);
    }
}
