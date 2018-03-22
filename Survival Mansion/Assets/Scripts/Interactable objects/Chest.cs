using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public Sprite[] chestStates = new Sprite[2];
    public GameObject[] chestItems = new GameObject[20];
    GameObject currentInterObj = null;
    bool chestOpen = false;

    private void Update()
    {
        //making sure chest doesn't activate more than once
        if (!chestOpen)
        {
            if (Input.GetButtonDown("Interact") && currentInterObj)
            {
                //change sprite and set chest to open
                this.GetComponent<SpriteRenderer>().sprite = chestStates[1];
                chestOpen = true;
                //generate items from chest
                for (int i = 0; i < Random.Range(1, 1); i++)
                {
                    GameObject clone;
                    clone = Instantiate(chestItems[Random.Range(0, chestItems.Length - 1)], this.transform);
                    clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10000, 10000), Random.Range(-15000, -1000)));
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        currentInterObj = other.gameObject;
    }


}
