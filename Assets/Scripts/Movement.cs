using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this row ensures that the script won't crush in case of absence of component Rigidbode
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    // т.к. логика движени€ изменилась мы выставили меньшее и более стандартное значение
    public float Speed = 5f;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // в даном случае допустимо использовать это здесь, но можно и в Update.
        // но раз уж вызываем здесь, то 
        // двигать будем использу€ множитель fixedDeltaTimе 
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(moveHorizontal) > 0.0f || Mathf.Abs(moveVertical) > 0.0f)
        {
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            // что бы скорость была стабильной в любом случае
            // и учитыва€ что мы вызываем из FixedUpdate мы умножаем на fixedDeltaTimе
            transform.Translate(movement * Speed * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            _sr.sortingOrder = -(int)(transform.position.y * 100);

            Vector2 directon = new Vector2(moveHorizontal, moveVertical);
            var angle = Vector2.SignedAngle(Vector2.up, directon);

            transform.GetChild(1).gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "AttackZone")
        {
            Debug.Log("Put health decrease here!");
        }
    }
}
