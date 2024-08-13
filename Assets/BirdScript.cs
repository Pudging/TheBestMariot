using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdAlive = true;
    private float bottomScreen;
    private float topScreen;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        topScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        bottomScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
        offScreen();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdAlive = false;
    }

    public void offScreen()
    {
        if (birdAlive) {
            if (transform.position.y > topScreen)
            {
                logic.gameOver();
                birdAlive = false;
            }
            else if (transform.position.y < bottomScreen)
            {
                logic.gameOver();
                birdAlive = false;
            }
        }
    }
    public bool isAlive()
    {
        return birdAlive;
    }
}
