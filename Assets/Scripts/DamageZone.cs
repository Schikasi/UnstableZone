using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private List<GameObject> GOinTrigger = new List<GameObject>();
    public float Damage = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var go in GOinTrigger)
        {
            var health = go.GetComponent<health>();
            health?.get_damage(Damage * Time.fixedDeltaTime);
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
