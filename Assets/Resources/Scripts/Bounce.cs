using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

    private float mStartTime;
    private float mDuration = 1;
    private bool mAnimating = false;

    private bool mUpwards = true;
    private float mSpeed = .1f;

	// Use this for initialization
	void Start () {
        mStartTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
	    if(!mAnimating)
        {
            if((Time.timeSinceLevelLoad - mStartTime) > mDuration)
            {
                mAnimating = true;
            }
        }
        else
        {
            if(mUpwards)
            {
                this.transform.position += this.transform.up * Time.deltaTime * mSpeed;
                if(this.transform.position.y > .1f)
                {
                    mUpwards = false;
                }
            }
            else
            {
                this.transform.position += this.transform.up * Time.deltaTime * mSpeed;
                if (this.transform.position.y <= .1f)
                {
                    mUpwards = true;
                    mAnimating = false;
                    this.transform.position = Vector3.zero;
                    mStartTime = Time.timeSinceLevelLoad;
                }
            }
        }
	}
}
