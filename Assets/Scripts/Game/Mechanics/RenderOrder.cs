using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{
    [SerializeField] private float zOffset = 0.0f;

    [SerializeField] private bool updatePerTick = false;

    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sortingOrder = -(int) ((transform.position.y + zOffset) * 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (updatePerTick)
        {
            _sr.sortingOrder = -(int) ((transform.position.y + zOffset) * 100);
        }
    }
}
