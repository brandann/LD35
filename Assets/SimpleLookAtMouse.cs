using UnityEngine;
using System.Collections;

public class SimpleLookAtMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var MouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseLocation.z = 0;
        this.transform.up = MouseLocation - this.transform.position;
	}
}
