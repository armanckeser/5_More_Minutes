using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameController mycontroller;
    public Text timerText;
    public Text overText;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (mycontroller.gameOver())
        {
            timerText.color = Color.red;
            overText.text = "GAME OVER";
            return;
        }
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
   

        timerText.text = minutes + ":" + seconds;
        overText.text = "";
	}
    
}
