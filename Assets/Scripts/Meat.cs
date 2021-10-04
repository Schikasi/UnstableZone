using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public float attackRadius = 0.5f;
    public float damage = 15f;
    public GameObject effect;

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
        bc.radius = attackRadius;
        _sr = GetComponent<SpriteRenderer>();
        _sr.sortingOrder = -(int)(transform.position.y * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GameObject eff = null;
        if (GOinTrigger.Count > 0) eff = Instantiate(effect, transform.position, Quaternion.identity);
        foreach (var go in GOinTrigger)
        { 
            var health = go.gameObject.GetComponent<health>();
            health?.get_damage(damage * Time.fixedDeltaTime);
        }
        if (GOinTrigger.Count > 0) Destroy(eff, 0.15f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        GOinTrigger.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GOinTrigger.Remove(other.gameObject);
    }
}
