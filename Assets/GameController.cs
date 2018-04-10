using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera realCamera;
    public Player myPlayer;
    int score;
    float secondsLasted;
    bool lost;
    public bool inRealWorld;

	// Use this for initialization
	void Start () {
        realCamera.enabled = true;
        Debug.Log(realCamera.fieldOfView);
        realCamera.fieldOfView += 20;
        Debug.Log(realCamera.fieldOfView);
        inRealWorld = true;
        secondsLasted = score = 0;
        lost = false;
	}
	

    public void lose()
    {
        lost = true;
    }

    public bool gameOver()
    {
        return lost;
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            if(inRealWorld)
            {
                myPlayer.transform.Translate(100, 100, 0, Space.World);
                realCamera.transform.Translate(100, 100, 0, Space.World);
                inRealWorld = false;
            }
            else
            {
                realCamera.transform.Translate(-100, -100, 0, Space.World);
                myPlayer.transform.Translate(-100, -100, 0, Space.World);
                inRealWorld = true;
            }
        }

        if(!lost)
        {
            secondsLasted += Time.deltaTime;
        }
        else
        {

        }
	}
}
