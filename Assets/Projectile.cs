using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float xSpeed, ySpeed;
    public Player source;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        transform.Translate(xSpeed * dt, ySpeed * dt, 0, Space.Self);
	}

}
