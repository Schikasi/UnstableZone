using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class enemy : MonoBehaviour
{
    public GameObject player;
    public float agroRadius;

    private bool isActive;
    private Rigidbody2D _rb; 
    private CircleCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        _rb = GetComponent<Rigidbody2D>();
        bc = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        bc.isTrigger = true;
        bc.radius = agroRadius;
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        if (!isActive) return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("horay!");
        isActive = true;
    }
}
