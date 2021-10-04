using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Anim : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        MoveAnim(moveHorizontal, moveVertical);

    }

    private void MoveAnim(float moveHorizontal, float moveVertical)
    {
        Vector2 directon = new Vector2(moveHorizontal, moveVertical);
        directon.Normalize();

        if (directon.sqrMagnitude > 0.1f)
        {
            var angle = -Vector2.SignedAngle(Vector2.up, directon);
            anim.SetFloat("Angle", angle);
            anim.SetFloat("Velocity", 1);
        }
        else
        {
            anim.SetFloat("Velocity", 0);
        }
    }
}
