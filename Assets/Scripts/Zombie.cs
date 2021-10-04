using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : MonoBehaviour
{
    public GameObject player;
    public float agroRadius;
    public float moveSpeed = 1;

    private Vector2 direct;

    private bool isActive;
    private Rigidbody2D _rb;
    private CircleCollider2D bc;
    private SpriteRenderer _sr;
    private Animator anim;

    public Vector2 Direct { get => direct;}

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        _rb = GetComponent<Rigidbody2D>();
        bc = gameObject.AddComponent<CircleCollider2D>();
        bc.isTrigger = true;
        bc.radius = agroRadius;
        _sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (isActive == false) return;

        Vector2 cell = player.transform.position;
        Vector2 cur = transform.position;
        direct = (cell - cur).normalized;
        if (Vector2.Distance(cur, cell) > moveSpeed)
        {
            float step = moveSpeed * Time.fixedDeltaTime;
            Vector2 movement = Vector2.MoveTowards(cur, cell, step);
            direct = movement - cur;
            transform.Translate(direct);

            MoveAnim(direct, 1);
            _sr.sortingOrder = -(int)(transform.position.y * 100);
        }
        else
        {
            MoveAnim(direct, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Hero_Anim>() != null && isActive == false)
        {
            isActive = true;
        }

    }

    private void MoveAnim(Vector2 direct, float vel)
    {
        direct.Normalize();
        var angle = -Vector2.SignedAngle(Vector2.up, direct);
        anim.SetFloat("Angle", angle);
        anim.SetFloat("Velocity", vel);
    }
}
