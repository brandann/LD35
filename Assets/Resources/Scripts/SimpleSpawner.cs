using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour {

    private float mStartTime;
    public float mDuration;
    public GameObject mSpawnedPrefab;
    public GameObject mRadiusObjectX;
    public float mDecreaseRate;

    private float mRadius;

	// Use this for initialization
	void Start () {
        mStartTime = Time.timeSinceLevelLoad;
        mRadius = mRadiusObjectX.transform.localScale.x / 2;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.timeSinceLevelLoad - mStartTime > mDuration)
        {
            mStartTime = Time.timeSinceLevelLoad;
            mDuration -= mDecreaseRate;
            var go = GameObject.Instantiate(mSpawnedPrefab);
            var dirX = Random.Range(-mRadius, mRadius);
            var dirY = Random.Range(mRadiusObjectX.transform.position.y, mRadius);
            Vector3 dir = new Vector3(dirX, dirY, 0);
            dir.Normalize();
            go.transform.position = this.transform.position + (dir * mRadius);

        }
	}
}
