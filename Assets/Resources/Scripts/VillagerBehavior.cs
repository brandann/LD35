using UnityEngine;
using System.Collections;

public class VillagerBehavior : MonoBehaviour {
    Vector3 mTarget = new Vector3(-3, -5, 0);
    Vector3 mDirection = new Vector3(0, 0, 0);
    public float mSpeed = 0;
    public bool mEvil;
    private Global mGlobal;
    private CameraShake mCameraShake;
    public GameObject HeroGameObject;

    public GameObject mBurstManager;
    public GameObject mBody;

    public GameObject killusGO;

    private bool mRevealed = false;

    // Use this for initialization
    void Start()
    {
        initTarget();
        initColor();
        mGlobal = GameObject.Find("Global").GetComponent<Global>();
        mCameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        HeroGameObject = GameObject.Find("Hero");
    }

    private void initColor()
    {
        mEvil = (Random.Range(0, 3) == 0) ? true : false;
        /*
        var SR = this.gameObject.GetComponent<SpriteRenderer>();
        if (mEvil)
        {
            SR.color = Color.red;
        }
        else
        {
            SR.color = Color.blue;
        }
        */
    }

    void OnMouseDown()
    {
        HeroGameObject.SendMessage("Shoot", this.gameObject);
    }

    public void Kill(bool score = true)
    {
        var go = GameObject.Instantiate(mBurstManager);
        go.transform.position = this.transform.position;


        if (score)
        {
            if (mEvil)
            {
                go.GetComponent<BurstManager>().mColor = Color.red;
                mGlobal.GainScore();
                mGlobal.MakeKill();
            }
            else
            {
                go.GetComponent<BurstManager>().mColor = Color.blue;
                mGlobal.LooseLife();
                mCameraShake.Shake();
                mGlobal.KilledVillager();
            }
        }
        else
        {
            if (mEvil)
            {
                go.GetComponent<BurstManager>().mColor = Color.red;
            }
            else
            {
                go.GetComponent<BurstManager>().mColor = Color.blue;
            }
        }
        Destroy(this.gameObject);
    }

    public void ShowKillMessage()
    {
        if (!mRevealed)
        {
            killusGO.SendMessage("ShowDontKillUs");
        }
    }

    public bool IsEvil()
    {
        return mEvil;
    }

    private void initTarget()
    {
        var targets = GameObject.FindGameObjectsWithTag("Finish");
        if (targets != null && targets.Length > 0)
        {
            mTarget = targets[Random.Range(0, targets.Length)].transform.position;
        }
        else
        {
            var sign = (Random.Range(0, 2) == 0) ? 1 : -1;
            mTarget = new Vector3(sign * 3, -5, 0);
        }

        mDirection = mTarget - this.transform.position;
        mDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + (mSpeed * mDirection) * Time.deltaTime;
        if ((this.transform.position - mTarget).magnitude < .1f)
        {
            AtEnd();
        }
    }

    void AtEnd()
    {
        if(this.mEvil)
        {
            mGlobal.LooseLife();
            mCameraShake.Shake();
        }
        else
        {
            mGlobal.GainScore();
            mGlobal.SaveVillager();
        }
        Destroy(this.gameObject);
    }

    public void Reveal()
    {
        if(mEvil)
        {
            mBody.GetComponent<SpriteRenderer>().color = Color.red;
            mBody.SendMessage("MakeEvil");
            this.mSpeed = 1.5f;
            mBody.GetComponent<SpriteRenderer>().enabled = true;
            mBody.SendMessage("HideBody");
            //mBody.SetActive(false);
            mRevealed = true;
        }
        else
        {
            //this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
