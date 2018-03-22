using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour {

    public Sprite[] bookStates = new Sprite[2];
    public GameObject[] bookshelfItems = new GameObject[5];
    GameObject currentInterObj = null;
    bool books = true;

    private void Update()
    {
        //making sure bookshelf doesn't activate more than once
        if (books)
        {
            if (Input.GetButtonDown("Interact") && currentInterObj)
            {
                //change sprite and set bookshelf to used
                this.GetComponent<SpriteRenderer>().sprite = bookStates[1];
                books = false;
                //generate book from the shelf  
                    GameObject clone;
                    clone = Instantiate(bookshelfItems[Random.Range(0, bookshelfItems.Length - 1)], this.transform);
                    clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10000, 10000), Random.Range(-15000, -1000)));
                

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        currentInterObj = other.gameObject;
    }
}
