using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : MonoBehaviour
{
    public GameObject player;
    public float agroRadius;
    public float moveSpeed = 1;
    public Vector2 attackZoneSize = new Vector2(1, 1);


    private bool isActive;
    private Rigidbody2D _rb; 
    private CircleCollider2D bc;
    private BoxCollider2D attackZone;
    private Vector2 movement = new Vector2(0.5f, 0.5f);
    
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        _rb = GetComponent<Rigidbody2D>();
        bc = gameObject.AddComponent<CircleCollider2D>();
        bc.isTrigger = true;
        bc.radius = agroRadius;
        attackZone = gameObject.AddComponent<BoxCollider2D>();
        attackZone.isTrigger = true;
        attackZone.size = attackZoneSize;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void fixedUpdate()
    {
        Debug.Log("must have been moved!");
        if (isActive == false) return;
        attackZone.transform.Translate(attackZoneSize * Time.fixedDeltaTime);
        
        //attackZone.offset = new Vector2(0.05f, 0.5f);
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    public void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            isActive = true;
            Debug.Log("activated!");
    }
}
