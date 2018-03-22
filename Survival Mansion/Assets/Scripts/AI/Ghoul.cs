using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : Movement, ILivingEntity {
    [SerializeField] private int health = 1;
    private int healthLeft;

    protected override void Start() {
        base.Start();
        healthLeft = health;
    }

    public void TakeHit(int damage) {
        if (healthLeft > 0) {
            healthLeft -= damage;
        }

        if (healthLeft <= 0) {
            Die();
        }
    }

    public void Die() {
        //play death animation
        //give loot?
        gameObject.SetActive(false);
    }
}