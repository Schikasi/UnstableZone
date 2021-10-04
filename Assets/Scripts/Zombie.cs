using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : MonoBehaviour
{
    public GameObject player;
    public float agroRadius;
    public float moveSpeed = 1;


    private bool isActive;
    private Rigidbody2D _rb; 
    private CircleCollider2D bc;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        _rb = GetComponent<Rigidbody2D>();
        bc = gameObject.AddComponent<CircleCollider2D>();
        bc.isTrigger = true;
        bc.radius = agroRadius;
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (isActive == false) return;
        float dx = 0f;
        float dy = 0f;
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < moveSpeed &&
            Mathf.Abs(transform.position.y - player.transform.position.y) < moveSpeed)
            return;
        if (transform.position.x > player.transform.position.x)
            dx = -moveSpeed;
        else dx = moveSpeed;
        if (transform.position.y > player.transform.position.y)
            dy = -moveSpeed;
        else dy = moveSpeed;
        Vector2 movement = new Vector2(dx, dy) * Time.fixedDeltaTime;
        transform.Translate(movement);
        _sr.sortingOrder = -(int)(transform.position.y * 100);

        //Vector2 directon = new Vector2(moveHorizontal, moveVertical);
        //var angle = Vector2.SignedAngle(Vector2.up, movement.normalized);
        //transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);

        //transform.GetChild(0).gameObject.transform.Translate(movement.normalized);
        //transform.GetChild(0).gameObject.transform.Translate(movement.normalized * new Vector2(1, 1));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Hero_Anim>() != null && isActive == false)
        {
            isActive = true;
        }
        
    }
}
