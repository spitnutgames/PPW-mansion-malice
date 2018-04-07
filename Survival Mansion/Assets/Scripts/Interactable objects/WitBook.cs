using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitBook : MonoBehaviour {

    public GameObject player;

    private PlayerStats statsScript;
    private int wit;
    private int statIncrease;

    private void UseBook()
    {
        wit = statsScript.wit / 5;
        statIncrease = Random.Range(45, 55) * wit;
        player.SendMessage("WitIncrease", statIncrease);
        Debug.Log("Increased wit by " + statIncrease);
    }

}
