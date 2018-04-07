using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuileBook : MonoBehaviour {

    public GameObject player;

    private PlayerStats statsScript;
    private int wit;
    private int statIncrease;

    private void Start()
    {
        statsScript = player.GetComponent<PlayerStats>();
    }

    private void UseBook()
    {
        wit = statsScript.wit / 5;
        statIncrease = Random.Range(45, 55) * wit;
        player.SendMessage("GuileIncrease", statIncrease);
        Debug.Log("Increased guile by " + statIncrease);
    }

}
