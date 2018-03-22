using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField] protected int attackRange = 1;
    [SerializeField] protected float attacksPerSecond = 1;
    [SerializeField] protected int damage = 1;
    private float attackSpeed;
    private float attackSpeedTimeHolder;

    protected Transform player;

    protected virtual void Start() {
        //Need to check if this is the correct
        attackSpeed = 60 / attacksPerSecond;
    }

    //Attacking with raycast
    protected virtual void AttackPlayer() {
        if(Time.time > attackSpeedTimeHolder) {
            //Play animation
            RaycastHit2D hit = Physics2D.Raycast(transform.position, DirToPlayer(), attackRange);

            if(hit.collider != null && hit.collider != this) {
                ILivingEntity l = hit.collider.GetComponent<ILivingEntity>();
                if(l != null) {
                    l.TakeHit(damage);
                }
            }
            attackSpeedTimeHolder = attackSpeed + Time.time;
        }
    }

    //Maybe delete and change to dir = forward when rotations are fixed
    protected Vector2 DirToPlayer() {
        return (player.position - transform.position).normalized;
    }

    //Checks if player is in range
    protected bool PlayerInRange(int range) {
        return Mathf.Abs(player.transform.position.x - transform.position.x) <= range
            && Mathf.Abs(player.transform.position.y - transform.position.y) <= range;
    }

    //Visualize attack range
    public virtual void OnDrawGizmos() {
        Gizmos.color = new Color(0, 1, 0, 0.1f);
        Gizmos.DrawCube(transform.position, new Vector2(attackRange * 2, attackRange * 2));
    }

    //AIController should give this information
    public Transform Player {
        set {
            player = value;
        }
    }
}