using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tyle : MonoBehaviour
{
    public string tyle_type = "default";
    private BoxCollider2D _bc;
    // Start is called before the first frame update
    void Start()
    {
        Transform formation = gameObject.GetComponent<Transform>();
        if ( formation != null )
        {
            _bc = gameObject.AddComponent<BoxCollider2D>();
            _bc.size = gameObject.GetComponent<SpriteRenderer>().size / 2;
            _bc.isTrigger = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == this.name) return;
    }
}
