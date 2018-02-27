using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class LostLife : MonoBehaviour {

    public Text livesText; // text object to display the number of lives

    // Use this for initialization
    void Start () {
        StartCoroutine("Wait");
	}
	
	// Update is called once per frame
	void Update () {
        // update the display for the player's number of lives
        if (PlayerPrefs.HasKey("Lives"))
        {
            livesText.text = "Lives: " + PlayerPrefs.GetInt("Lives");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        if (PlayerPrefs.GetInt("Lives") > 0)
        {
            SceneManager.LoadScene("goalTest");
        }
        else
        {
            SceneManager.LoadScene("lostGame");
        }
    }
}
