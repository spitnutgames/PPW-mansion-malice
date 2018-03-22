using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    public bool inventory; //if ture this object can be storedc in inventory


    public void DoInteraction()
    {
        //picked up and put in inventory
        gameObject.SetActive(false);
    }

}
