﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
    public GameObject[] inventory = new GameObject[10];
       public void AddItem(GameObject item)
       {
            bool itemAdded = false;
            for (int i = 0; i < inventory.Length; i++)
            {
            if (inventory[i] == null)
                {
                inventory[i] = item;
                itemAdded = true;
                    break;
                }
            }
       }
}
