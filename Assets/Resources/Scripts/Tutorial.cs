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
        TutorialText.Add("Shaman, a great plague is sweeping the towns! The Villagers from the neighboring tribes are flocking to the sanctuary...");
        TutorialText.Add("The plague is allowing the evil spirits of our ancestors to disguise as our brethren...");
        TutorialText.Add("Use your ancient Shaman powers of <b><color=teal>“RIGHT-CLICKING”</color></b> (whatever that means) to reveal our foes!");
        TutorialText.Add("Look with your <b><color=purple>“MOUSE”</color></b> and <b><color=teal>“LEFT-CLICK”</color></b> to destroy the evil among us. Don’t ask me what that means, I’m just a simple gatherer...");

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
