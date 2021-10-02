using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class enemy : MonoBehaviour
{
    private bool isActive;
    private Rigidbody2D _rb;
    public GameObject player;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        _rb = GetComponent<Rigidbody2D>();
        bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.isTrigger = true;
        bc.size = new Vector2(50f, 50f);
        
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
