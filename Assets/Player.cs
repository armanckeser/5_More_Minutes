using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameController myController;
    public Projectile projectile;
    float speed = 0.2f;
    float fireCooldown = 0f;
    // Use this for initialization
    void Start()
    {
        transform.Translate(0, 0, 0);
    }
        // Update is called once per frame
    void Update () {
        fireCooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(- 1 *speed, 0, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -1 * speed, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed, 0, 0), Space.World);
        }

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        //myController.getActiveCamera().transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.AngleAxis(angle - 90.0f, Vector3.forward);

        
        if(Input.GetMouseButtonDown(0) && fireCooldown <= 0 && !myController.inRealWorld)
        {
            Projectile newProjectile = Instantiate(projectile);
            newProjectile.transform.SetPositionAndRotation(GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            newProjectile.transform.Translate(0, 3, 0, Space.Self);
            newProjectile.xSpeed = 0.0f;
            newProjectile.ySpeed = 10.0f;
            fireCooldown = 0.5f;
        }
    }
}
