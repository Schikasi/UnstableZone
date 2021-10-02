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

        Vector2 directon = new Vector2(moveHorizontal, moveVertical);
        directon.Normalize();

        if (directon.sqrMagnitude > 0.1f)
        {
            var angle = -Vector2.SignedAngle(Vector2.up, directon);
            if (angle > -45 && angle <= 45)
            {
                anim.SetInteger("Direction", 1);
            }
            else if (angle > 45 && angle <= 135)
            {
                anim.SetInteger("Direction", 2);
            }
            else if (angle > 135 || angle <= -135)
            {
                anim.SetInteger("Direction", 3);
            }
            else if (angle > -135 && angle <= 45)
            {
                anim.SetInteger("Direction", 4);
            }
        }
        else
        {
            anim.SetInteger("Direction", 0);
        }

    }
}
