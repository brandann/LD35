using UnityEngine;
using System.Collections;

public class HeroBehavior : MonoBehaviour {

    private Global mGlobal;
    public GameObject mVisionObject;
    public GameObject mArrowPrefab;

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
                return;
            }
        }
        mVisionObject.SetActive(false);
	}

    public void Shoot(GameObject go)
    {
        var arrow = GameObject.Instantiate(mArrowPrefab);
        arrow.transform.position = this.transform.position;
        var AB = arrow.GetComponent<ArrowBehavior>();
        AB.mTargetGameObject = go;
    }
}
