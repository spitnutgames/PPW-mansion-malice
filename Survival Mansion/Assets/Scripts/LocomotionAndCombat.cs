using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LocomotionAndCombat : MonoBehaviour {
    public GameObject player;
    public GameObject levelManager;
    public Rigidbody2D rb2D;
    public float meleeRange;
    public Transform meleePoint;
    public Image healthBar;
    public Text health;

    private int healthLeft;
    private CameraManager cameraScript;
    private PlayerStats statsScript;
    private int agility;
    private int meleeDamage;
    private bool minimapOff;

    private void Update()
    {
        minimapOff = cameraScript.camSwitch;
        agility = statsScript.agility;
        meleeDamage = statsScript.strength / 50;
    }
    private void Start()
    {
        cameraScript = levelManager.GetComponent<CameraManager>();
        statsScript = player.GetComponent<PlayerStats>();
        rb2D = GetComponent<Rigidbody2D>();
        healthLeft = statsScript.strength / 5;
    }
    void FixedUpdate () {
        Controls();
    }

    public void TakeHit(int damage)
    {
        if (healthLeft > 0)
        {
            healthLeft -= damage;
            healthBar.fillAmount = healthLeft / (statsScript.strength / 5);
            health.text = healthLeft.ToString();
        }

        if (healthLeft <= 0)
        {
            Die();
        }
    }

    public void Controls()
    {
        //check to make sure minimap isn't active
        if (minimapOff)
        {
            //melee combat
            if (Input.GetButtonDown("Melee"))
            {
                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, meleeRange);
                for (int i = 0; i < hitObjects.Length; i++)
                {
                    hitObjects[i].SendMessage("TakeHit", meleeDamage, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Hit " + hitObjects[i].name);
                }
            }
        
       
            //movement
            if (Input.GetKey("a") & Input.GetKey("w")) {
                rb2D.AddForce(new Vector2(-agility * 20, agility * 20) * Time.fixedDeltaTime);
                rb2D.rotation = 0;
            }
            else if (Input.GetKey("w") & Input.GetKey("d"))
            {
                rb2D.AddForce(new Vector2(agility * 20, agility * 20) * Time.fixedDeltaTime);
                rb2D.rotation = -0;
            }
            else if (Input.GetKey("s") & Input.GetKey("d"))
            {
                rb2D.AddForce(new Vector2(agility * 20, -agility * 20) * Time.fixedDeltaTime);
                rb2D.rotation = -0;
            }
            else if (Input.GetKey("s") & Input.GetKey("a"))
            {
                rb2D.AddForce(new Vector2(-agility * 20, -agility * 20) * Time.fixedDeltaTime);
                rb2D.rotation = 0;
            }
            else if (Input.GetKey("w"))
            {
                rb2D.AddForce(new Vector2(0, agility * 20) * Time.fixedDeltaTime);
                rb2D.rotation = 0;
            }
            else if (Input.GetKey("a"))
            {
                rb2D.AddForce(new Vector2(-agility * 20, 0) * Time.fixedDeltaTime);
                rb2D.rotation = 0;
            }
            else if (Input.GetKey("s"))
            {
                rb2D.AddForce(new Vector2(0, -agility * 20) * Time.fixedDeltaTime);
                rb2D.rotation = -0;
            }
            else if (Input.GetKey("d"))
            {
                rb2D.AddForce(new Vector2(agility * 20, 0) * Time.fixedDeltaTime);
                rb2D.rotation = -0;
            }
        }
    }
   void Die()
    {

    }
}
