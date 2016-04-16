using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
    
    public GameObject mTargetGameObject;
    private float mSpeed=12;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(mTargetGameObject == null)
        {
            Destroy(this.gameObject);
        }
        this.transform.up = mTargetGameObject.transform.position - this.transform.position;
        this.transform.position += Time.deltaTime * mSpeed * this.transform.up;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject == mTargetGameObject)
        {
            coll.gameObject.SendMessage("Kill");
            Destroy(this.gameObject);
        }
    }
}
