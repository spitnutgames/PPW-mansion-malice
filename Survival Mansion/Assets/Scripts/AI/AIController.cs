using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    [Tooltip("Range when AI becomes active again")]
    [SerializeField] private int closeRange = 100;
    [Tooltip("Check frequency for close range AI")]
    [SerializeField] private float timeToCheckCloseRange = 0.5f;
    [Tooltip("Used to determen when to check if AI is in close range to player")]
    [SerializeField] private int longRange = 1000;
    [Tooltip("Check frequency for long range AI")]
    [SerializeField] private float timeToCheckLongRange = 1f;

    private Transform player;

    private Queue<Transform> farEnemies = new Queue<Transform>();
    private Queue<Transform> closeEnemies = new Queue<Transform>();
    private Queue<Transform> activeEnemies = new Queue<Transform>();

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Finds all AI in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("AI");
        foreach (GameObject item in enemies) {
            activeEnemies.Enqueue(item.transform);

            //Adds player reference to an AI
            Attack attack = item.GetComponent<Attack>();
            if(attack != null) {
                attack.Player = player;
            }
        }

        InvokeRepeating("CheckActiveEnemies", 0, 0.2f);
        InvokeRepeating("CheckCloseEnemies", 0.5f, 0.5f);
        InvokeRepeating("CheckFarEnemies", 1, 1);
    }

    //Check if AI is moved away from player far enough to be disabled
    private void CheckActiveEnemies() {
        int count = activeEnemies.Count;

        for (int i = 0; i < count; i++) {
            Transform t = activeEnemies.Dequeue();
            if(!RangeCheck(closeRange, t)) {
                t.gameObject.SetActive(false);
                closeEnemies.Enqueue(t);
                continue;
            }

            activeEnemies.Enqueue(t);
        }
    }

    //Check if AI is in close range to be activated
    private void CheckCloseEnemies() {
        int count = closeEnemies.Count;

        for (int i = 0; i < count; i++) {
            Transform g = closeEnemies.Dequeue();
            if(RangeCheck(closeRange, g)) {
                g.gameObject.SetActive(true);
                activeEnemies.Enqueue(g);
                continue;
            }

            if(!RangeCheck(longRange, g)) {
                farEnemies.Enqueue(g);
                continue;
            }

            closeEnemies.Enqueue(g);
        }
    }

    //Checks if AI is in close range to be checked more ofter
    private void CheckFarEnemies() {
        int count = farEnemies.Count;

        for (int i = 0; i < count; i++) {
            Transform t = farEnemies.Dequeue();
            if(RangeCheck(longRange, t)) {
                closeEnemies.Enqueue(t);
                continue;
            }

            //Do I need to check if player managed to travel (longRange - closeRange) during check period?
            //If player managed - Ai will not be activated tight away.
            //It will be activated on the next CheckCloseEnemies iteration

            farEnemies.Enqueue(t);
        }
    }

    private bool RangeCheck(int range, Transform t) {
        return Mathf.Abs(player.transform.position.x - t.position.x) <= range
            && Mathf.Abs(player.transform.position.y - t.position.y) <= range;
    }
}