using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocomotionAndCombat : MonoBehaviour {
    public GameObject player;
    public Rigidbody2D rb2D;
    public Sprite[] playerSprites = new Sprite[8];
    public float meleeRange;
    public Transform meleePoint;

    private Animator anim;
    private PlayerStats statsScript;
    private int agility;
    private int meleeDamage;

    private void Update()
    {
        agility = statsScript.agility;
        meleeDamage = statsScript.agility / 5;
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
        if (Input.GetButtonDown("Melee")){
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, meleeRange);
            for (int i = 0; i < hitObjects.Length; i++)
            {
                hitObjects[i].SendMessage("TakeHit", meleeDamage, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Hit "+hitObjects[i].name);
            }
        }


        if (Input.GetKey("a") & Input.GetKey("w")) {
            rb2D.AddForce(new Vector2(-agility*20,agility*20) * Time.fixedDeltaTime);
            rb2D.rotation = 45;
        }
        else if (Input.GetKey("w") & Input.GetKey("d"))
        {
            rb2D.AddForce(new Vector2(agility*20, agility*20) * Time.fixedDeltaTime);
            rb2D.rotation = -45;
        }
        else  if (Input.GetKey("s") & Input.GetKey("d"))
        {
            rb2D.AddForce(new Vector2(agility*20, -agility*20) * Time.fixedDeltaTime);
            rb2D.rotation = -135;
        }
        else if (Input.GetKey("s") & Input.GetKey("a"))
        {
            rb2D.AddForce(new Vector2(-agility*20, -agility*20) * Time.fixedDeltaTime);
            rb2D.rotation = 135;
        }
        else if (Input.GetKey("w"))
        {
            rb2D.AddForce(new Vector2(0, agility*20) * Time.fixedDeltaTime);
            rb2D.rotation = 0;
        }
        else if (Input.GetKey("a"))
        {
            rb2D.AddForce(new Vector2(-agility*20, 0) * Time.fixedDeltaTime);
            rb2D.rotation = 90;
        }
        else if (Input.GetKey("s"))
        {
            rb2D.AddForce(new Vector2(0, -agility*20) * Time.fixedDeltaTime);
            rb2D.rotation = 180;
        }
        else if (Input.GetKey("d"))
        {
            rb2D.AddForce(new Vector2(agility*20, 0) * Time.fixedDeltaTime);
            rb2D.rotation = -90;
        }
    }
}
