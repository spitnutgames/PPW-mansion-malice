using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTable : MonoBehaviour {

    public GameObject[] endTableItems = new GameObject[10];
    GameObject currentInterObj = null;
    bool endTableOpen = false;

    private void Update()
    {
        //making sure chest doesn't activate more than once
        if (!endTableOpen)
        {
            if (Input.GetButtonDown("Interact") && currentInterObj)
            {
                endTableOpen = true;
                //generate items from chest
                for (int i = 0; i < Random.Range(-1, 2); i++)
                {
                    GameObject clone;
                    clone = Instantiate(endTableItems[Random.Range(0, endTableItems.Length - 1)], this.transform);
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
