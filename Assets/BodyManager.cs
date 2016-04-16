using UnityEngine;
using System.Collections;

public class BodyManager : MonoBehaviour {

    public GameObject[] BodyA;
    public GameObject[] BodyB;
    public GameObject[] BodyC;

	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, 3);
        if(rand == 0)
        {
            BodyA[0].SetActive(true);
            BodyA[1].SetActive(true);
        }
        else if(rand == 1)
        {
            BodyB[0].SetActive(true);
            BodyB[1].SetActive(true);
        }
        else if(rand == 2)
        {
            BodyC[0].SetActive(true);
            BodyC[1].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
