using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroHareket : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animasyon;
    private SpriteRenderer sprite;
    private BoxCollider2D box;

    [SerializeField] private LayerMask ziplananyer;


    private float yonX = 0f;
    [SerializeField] private float yurumehiz = 7f;
    [SerializeField] private float ziplamahiz = 7f;

    private enum MovementState { durma, yurume, ziplama, dusme }

    [SerializeField] private AudioSource jumpSoundEffect;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animasyon = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yonX = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(yonX * yurumehiz, rigid.velocity.y);


        if (Input.GetKeyDown("space") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rigid.velocity = new Vector2(rigid.velocity.x, ziplamahiz);
        }
        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (yonX > 0f)
        {
            state = MovementState.yurume;
            sprite.flipX = false;
        }
        else if (yonX < 0f)
        {
            state = MovementState.yurume;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.durma;
        }


        if (rigid.velocity.y > .1f)
        {
            state = MovementState.ziplama;
        }
        else if (rigid.velocity.y < -.1f)
        {
            state = MovementState.dusme;
        }

        animasyon.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, ziplananyer);
    }
}