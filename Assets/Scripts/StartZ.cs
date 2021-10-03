using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZ : MonoBehaviour
{
    public float zOffset = 0.0f;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sortingOrder = -(int)((transform.position.y + zOffset) * 100);
    }

}
