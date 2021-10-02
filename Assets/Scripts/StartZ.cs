using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZ : MonoBehaviour
{
    public float zOffset = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        var newPosition = transform.position;
        newPosition.z = newPosition.y + zOffset;
        transform.position = newPosition;
    }

}
