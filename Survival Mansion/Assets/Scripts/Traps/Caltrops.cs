using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caltrops : MonoBehaviour {
    public GameObject player;
    public int durability = 10;

    [SerializeField]private int caltropsDamage = 35;
    private PlayerStats statsScript;
    private int guile;

    private void Start()
    {
        statsScript = player.GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            guile = statsScript.guile / 500;
            if (durability > 0) {
                Collider2D[] hitObjects = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0);
                for (int i = 0; i < hitObjects.Length; i++)
                {
                    hitObjects[i].SendMessage("TakeHit", caltropsDamage * guile, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Caltrops trapped " + hitObjects[i].name);
                    durability--;
                }
            }
        }
    }
}
