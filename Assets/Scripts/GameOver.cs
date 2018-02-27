using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Wait");
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        PlayerPrefs.SetInt("Time", 30);
        SceneManager.LoadScene("menu");
    }
}
