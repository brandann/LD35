using UnityEngine;
using System.Collections;

public class VisionBehavior : MonoBehaviour {

    private const string VILLAGE_TAG = "Villager";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        print("COL");
        if (coll.gameObject.tag == VILLAGE_TAG)
            coll.gameObject.SendMessage("Reveal");
    }
}
