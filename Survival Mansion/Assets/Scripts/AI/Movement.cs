using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : Attack {
    protected Rigidbody2D rb;
    [SerializeField] protected int movementSpeed = 2;
    [SerializeField] protected int chaseSpeed = 2;
    [SerializeField] protected Transform movePoints;
    private Transform[] points;
    private int index;

    [SerializeField] protected int detectionRange;

    protected override void Start() {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        if(movePoints == null) {
            Debug.LogError("No points were assigned");
            return;
        }
        points = new Transform[movePoints.childCount];
        for (int i = 0; i < points.Length; i++) {
            points[i] = movePoints.GetChild(i).transform;
        }

        if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    protected virtual void FixedUpdate() {
        if (PlayerInRange(attackRange)) {
            AttackPlayer();
            return;
        }

        if(points.Length == 0 || points == null) {
            Debug.LogError("Need points to move between");
            return;
        }

        Move();
    }

    //Moves between points or to a player position
    //TODO: Smooth out movement
    protected virtual void Move() {
        Vector2 dir;
        dir = PlayerInRange(detectionRange) ? (player.transform.position - transform.position).normalized : (points[index].position - transform.position).normalized;
        Rotate(dir);
        rb.MovePosition(rb.position + dir * Time.deltaTime * movementSpeed);

        if(Vector2.Distance(transform.position, points[index].position) < 0.1) {
            index++;
            if(index >= points.Length) {
                index = 0;
            }
        }
    }

    //Need to put corresponding sprite to corresponding rotation or just rotate, idk right now
    protected void Rotate(Vector2 dir) {
        if(dir.x < 0 && dir.y < 0) {
            //down to left
        }
        if(dir.x < 0 && dir.y > 0) {
            //up to left
        }
        if(dir.x > 0 && dir.y < 0) {
            //down to right
        }
        if(dir.x > 0 && dir.y > 0) {
            //up to right
        }
        if(dir.x < 0) {
            //left
        }
        if(dir.x > 0) {
            //right
        }
        if(dir.y < 0) {
            //down
        }
        if(dir.y > 0) {
            //up
        }
    }

    //To visualize detection range
    public override void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 0, 0.1f);
        Gizmos.DrawCube(transform.position, new Vector3(detectionRange * 2, detectionRange * 2));
        base.OnDrawGizmos();
    }
}