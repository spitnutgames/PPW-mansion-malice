using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgilityBook : MonoBehaviour {

    public GameObject player;

    private PlayerStats statsScript;
    private int wit;
    private int statIncrease;

    private void UseBook()
    {
        wit = statsScript.wit / 5;
        statIncrease = Random.Range(45, 55) * wit;
        player.SendMessage("AgilityIncrease", statIncrease);
        Debug.Log("Increased agility by " + statIncrease);
    }

}
