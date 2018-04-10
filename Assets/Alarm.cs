using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {

    public GameController myController;
    float timeCounter;
    SpriteRenderer myRenderer;
    public float detonationTime;
	// Use this for initialization
	void Start () {
        timeCounter = 0.0f;
        myRenderer = GetComponent<SpriteRenderer>();
        setColor();
		//set sprite's color to green
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        setColor();
    }

    void setColor()
    {
        if(timeCounter >= detonationTime)
        {
            myController.lose();
            timeCounter = detonationTime;
        }
        float red = timeCounter/detonationTime;
        float green = (detonationTime - timeCounter)/detonationTime;
        float blue = 0.0f;
        myRenderer.color = new Color(red, green, blue);
    }

    private void OnMouseDown()
    {
        timeCounter = 0.0f;
        detonationTime -= 0.1f;
        setColor();
    }
}
