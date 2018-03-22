using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocomotionAndCombat : MonoBehaviour {
    public GameObject player;
    public Rigidbody2D rb2D;
    public Sprite[] playerSprites = new Sprite[8];

    private Animator anim;
    private PlayerStats statsScript;
    private int movementSpeed;

    private void Update()
    {
        movementSpeed = statsScript.agility;
    }
    private void Start()
    {
        statsScript = player.GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate () {
        Controls();
    }
    public void Controls()
    {
        if (Input.GetKey("a") & Input.GetKey("w")) {
            rb2D.AddForce(new Vector2(-movementSpeed*20,movementSpeed*20) * Time.fixedDeltaTime);
            rb2D.rotation = 45;
        }
        else if (Input.GetKey("w") & Input.GetKey("d"))
        {
            rb2D.AddForce(new Vector2(movementSpeed*20, movementSpeed*20) * Time.fixedDeltaTime);
            rb2D.rotation = -45;
        }
        else  if (Input.GetKey("s") & Input.GetKey("d"))
        {
            rb2D.AddForce(new Vector2(movementSpeed*20, -movementSpeed*20) * Time.fixedDeltaTime);
            rb2D.rotation = -135;
        }
        else if (Input.GetKey("s") & Input.GetKey("a"))
        {
            rb2D.AddForce(new Vector2(-movementSpeed*20, -movementSpeed*20) * Time.fixedDeltaTime);
            rb2D.rotation = 135;
        }
        else if (Input.GetKey("w"))
        {
            rb2D.AddForce(new Vector2(0, movementSpeed*20) * Time.fixedDeltaTime);
            rb2D.rotation = 0;
        }
        else if (Input.GetKey("a"))
        {
            rb2D.AddForce(new Vector2(-movementSpeed*20, 0) * Time.fixedDeltaTime);
            rb2D.rotation = 90;
        }
        else if (Input.GetKey("s"))
        {
            rb2D.AddForce(new Vector2(0, -movementSpeed*20) * Time.fixedDeltaTime);
            rb2D.rotation = 180;
        }
        else if (Input.GetKey("d"))
        {
            rb2D.AddForce(new Vector2(movementSpeed*20, 0) * Time.fixedDeltaTime);
            rb2D.rotation = -90;
        }
    }
}
