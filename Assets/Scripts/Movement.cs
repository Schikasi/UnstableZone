using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//эта строчка гарантирует что наш скрипт не завалитс€ ести на плеере будет отсутствовать компонент Rigidbody
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    // т.к. логика движени€ изменилась мы выставили меньшее и более стандартное значение
    public float Speed = 5f;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // что бы скорость была стабильной в любом случае
        // и учитыва€ что мы вызываем из FixedUpdate мы умножаем на fixedDeltaTimе
        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }
}
