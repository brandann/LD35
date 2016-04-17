using UnityEngine;
using System.Collections;

public class noDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
