using System.Collections;
using System.Collections.Generic;

using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider2D))]



public class Ainmations : MonoBehaviour
{

    [SerializeField]
    public Vector2 _DeltaForce;



    private Vector2 _LastDirection;


    private Rigidbody2D RGB;

    public float speed = 2;

    public Animator anim;

    private CapsuleCollider2D Boxcollider;


    private bool IsMoving;
    void Awake()
    {
        anim = GetComponent<Animator>();
        RGB = GetComponent<Rigidbody2D>();





    }


    void Start()
    {
        RGB.gravityScale = 0;
        RGB.constraints = RigidbodyConstraints2D.FreezeRotation;

    }


    void Update()
    {
        CheckInput();
    }


    void CheckInput()
    {
        IsMoving = false;

        _LastDirection = RGB.velocity;


        var _H = Input.GetAxisRaw("Horizontal");
        var _V = Input.GetAxisRaw("Vertical");

        if (_H < 0 || _H > 0 || _V < 0 || _V > 0)
        {
            IsMoving = true;
        }

        _DeltaForce = new Vector2(_H, _V);

        SendAnimInfo();

    }

    void SendAnimInfo()
    {
        anim.SetFloat("XSpeed", RGB.velocity.x);
        anim.SetFloat("YSpeed", RGB.velocity.y);

        anim.SetFloat("Last X", _LastDirection.x);

        anim.SetFloat("Last Y", _LastDirection.y);

        anim.SetBool("IsMoving", IsMoving);


    }

    void CalculateMovement(Vector2 _PlayerForce)
    {

    }

}
