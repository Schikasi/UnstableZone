using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public GameObject player;
    public float agroRadius;
    public float damage;

    private Rigidbody2D _rb;
    private CircleCollider2D bc;
    private SpriteRenderer _sr;
    private List<GameObject> GOinTrigger = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        bc = gameObject.AddComponent<CircleCollider2D>();
        bc.isTrigger = true;
        bc.radius = agroRadius;
        _sr = GetComponent<SpriteRenderer>();
        _sr.sortingOrder = -(int)(transform.position.y * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        foreach (var go in GOinTrigger)
        { 
            var health = go.gameObject.GetComponent<health>();
            health?.get_damage(damage * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Hero")
        {
            var  health = collision.gameObject.GetComponent<health>();
            health?.get_damage(damage * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GOinTrigger.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GOinTrigger.Remove(other.gameObject);
    }
}
