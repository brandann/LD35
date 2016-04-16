using UnityEngine;
using System.Collections;

public class HeroBehavior : MonoBehaviour {

    private Global mGlobal;
    public GameObject mVisionObject;

	// Use this for initialization
	void Start () {
        mGlobal = GameObject.Find("Global").GetComponent<Global>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButton(1))
        {
            if(mGlobal.HasPower())
            {
                mGlobal.deltaPower(-1);
                mVisionObject.SetActive(true);
            }
        }
        else
        {
            mVisionObject.SetActive(false);
        }
	}
}
