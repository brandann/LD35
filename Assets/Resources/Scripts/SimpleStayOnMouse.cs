using UnityEngine;
using System.Collections;

public class SimpleStayOnMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        this.transform.position = mp;
	}
}
