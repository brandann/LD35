using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Tutorial : MonoBehaviour {

    public List<string> TutorialText;
    private int index = 0;
    public GameObject mText;

	// Use this for initialization
	void Start () {
	    TutorialText = new List<string>();
        TutorialText.Add("Shaman, A Great Plague Is Sweeping The Towns! The Villagers From The Neighboring Tribes Are Flocking To The Sanctuary...");
        TutorialText.Add("The Plague Is Allowing The Evil Spirits Of Our Ancestors to Disguise As Our Brethren...");
        TutorialText.Add("Use Your Ancient Shaman Powers Of <b><color=teal>“RIGHT-CLICKING”</color></b> To Reveal Our Foes!");
        TutorialText.Add("Aim With Your <b><color=purple>“MOUSE”</color></b>");
        TutorialText.Add("<b><color=teal>“LEFT-CLICK”</color></b> To Destroy The Evil Shape Shifting Goats Among Us...");
        TutorialText.Add("Don’t Ask Me What That Means, I’m Just A Simple Gatherer...");
        TutorialText.Add("Don't Kill Your Own People. They Will Turn On You!");

        mText.GetComponent<Text>().text = TutorialText[index];
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonUp(0))
        {
            index++;
            if(index == TutorialText.Count)
            {
                Application.LoadLevel("Game");
                return;
            }
            mText.GetComponent<Text>().text = TutorialText[index];
        }
	}
}
